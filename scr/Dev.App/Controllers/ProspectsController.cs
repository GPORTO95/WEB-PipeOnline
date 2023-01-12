using AutoMapper;
using Dev.App.Extensions;
using Dev.App.ViewModels;
using Dev.Business.Interfaces;
using Dev.Business.Models;
using KissLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.App.Controllers
{
    [Route("projetos")]
    [Authorize]
    public class ProspectsController : BaseController
    {
        private readonly IProspectRepository _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISegmentRepository _segmentRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IProspectService _service;
        private readonly IMapper _mapper;
        //private readonly ILogger //_logger;

        public ProspectsController(
            IProspectRepository context,
            IProspectService service,
            ICategoryRepository categoryRepository,
            IEmployeeRepository employeeRepository,
            ICustomerRepository customerRepository,
            ISegmentRepository segmentRepository,
            ICompanyRepository companyRepository,
            IMapper mapper,
            //ILogger logger,
            INotifier notificador) : base(notificador)
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
            _segmentRepository = segmentRepository;
            _companyRepository = companyRepository;
            _service = service;
            _mapper = mapper;
            ////_logger = logger;
        }

        // GET: Prospects
        [Route("lista-de-projetos")]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string mensagem)
        {
            ////_logger.LogDebug("Listagem de projetos");

            if (!string.IsNullOrEmpty(mensagem))
                ViewBag.Mensagem = mensagem;

            var lista = _mapper.Map<IEnumerable<ProspectViewModel>>(await _context.ObterTodos());

            var vm = new ProspectListViewModel
            {
                ProspectViewModels = lista,
                Customers = _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.ObterTodos()),
                Employees = _mapper.Map<IEnumerable<EmployeeViewModel>>(await _employeeRepository.ObterTodos())

            };

            return View(vm);
        }

        [Route("lista-de-projetos")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SearchProspects(ProspectListViewModel prospectViewModel)
        {
            //_logger.LogDebug("Listagem de projetos filtrados");

            var lista = _mapper.Map<IEnumerable<ProspectViewModel>>(await _context.ObterTodos());

            if (!string.IsNullOrEmpty(prospectViewModel.CustomerIds))
            {
                var customers = new List<Guid>();
                foreach (var item in prospectViewModel.CustomerIds.Split(','))
                {
                    customers.Add(Guid.Parse(item));
                }
                lista = lista.Where(x => customers.Contains(x.CustomerId));
            }

            if (!string.IsNullOrEmpty(prospectViewModel.Types))
            {
                var types = new List<int>();
                foreach (var item in prospectViewModel.Types.Split(','))
                {
                    types.Add(Convert.ToInt32(item));
                }
                lista = lista.Where(x => types.Contains(x.Type));
            }

            if (!string.IsNullOrEmpty(prospectViewModel.Status))
            {
                var status = new List<string>();
                foreach (var item in prospectViewModel.Status.Split(','))
                {
                    status.Add(item);
                }
                lista = lista.Where(x => status.Contains(x.Status));
            }

            if (!string.IsNullOrEmpty(prospectViewModel.EmployeeIds))
            {
                var employees = new List<Guid>();
                foreach (var item in prospectViewModel.EmployeeIds.Split(','))
                {
                    employees.Add(Guid.Parse(item));
                }
                lista = lista.Where(x => employees.Contains(x.EmployeeId));
            }

            if (!string.IsNullOrEmpty(prospectViewModel.DateOpening))
            {
                var inicio = DateTime.Parse(prospectViewModel.DateOpening.Substring(0, 10));
                var fim = DateTime.Parse(prospectViewModel.DateOpening.Substring(15, 10));
                lista = lista.Where(x => x.Opening >= inicio && x.Opening <= fim);
            }

            if (!string.IsNullOrEmpty(prospectViewModel.Temperatures))
            {
                var temperatures = new List<string>();
                foreach (var item in prospectViewModel.Temperatures.Split(','))
                {
                    temperatures.Add(item);
                }
                lista = lista.Where(x => temperatures.Contains(x.Temperature.ToString()));
            }

            var vm = new ProspectListViewModel
            {
                ProspectViewModels = lista
            };

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_Lista", vm.ProspectViewModels) });
        }


        // GET: Prospects/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var prospectViewModel = await _context.ProspectViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (prospectViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(prospectViewModel);
        //}

        // GET: Prospects/Create
        //[ClaimsAuthorize("Prospect", "Adicionar")]
        [HttpGet]
        [Route("projeto")]
        public async Task<IActionResult> AddOrEdit(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                //_logger.LogDebug("Pagina de novo projeto");

                var prospectViewModel = await PopularListas(new ProspectViewModel());
                
                return View(prospectViewModel);
            }
            else
            {
                //_logger.LogDebug("Pagina de edição projeto");

                var prospectViewModel = _mapper.Map<ProspectViewModel>(await _context.ObterPorId(id));

                prospectViewModel = await PopularListas(prospectViewModel);
                prospectViewModel.ProspectEmployeeId = string.Join(",", prospectViewModel.ProspectEmployees.Select(pe => pe.EmployeeId));
                
                if (prospectViewModel == null)
                    return NotFound();

                return View(prospectViewModel);
            }
        }

        //[ClaimsAuthorize("Prospect", "Adicionar")]
        [HttpPost]
        [Route("projeto")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Guid id, ProspectViewModel prospectViewModel)
        {
            prospectViewModel = await PopularListas(prospectViewModel);
            string mensagem;

            if (!ModelState.IsValid)
            {
                //_logger.LogWarning("Erro no estado da model");

                prospectViewModel.Customer = new CustomerViewModel();

                return View(prospectViewModel);
            }

            if (!string.IsNullOrEmpty(prospectViewModel.ProspectEmployeeId))
            {
                foreach (var item in prospectViewModel.ProspectEmployeeId.Split(','))
                {
                    prospectViewModel.AddProspectEmployee(new ProspectEmployeeViewModel(Guid.Parse(item)));
                }
            }

            var prospect = _mapper.Map<Prospect>(prospectViewModel);

            if (id == null || id == Guid.Empty)
            {
               await _service.Adicionar(prospect);

                if (!OperacaoValida())
                {
                    //_logger.LogWarning("Erro na validação da regra negocio");

                    return View(prospectViewModel);
                }

                var idPsp = _mapper.Map<ProspectViewModel>(await _context.ObterPorId(prospect.Id)).IdPsp;

                mensagem = $"Projeto {idPsp} criado com sucesso!";

                //_logger.LogInformation(mensagem);
            }
            else
            {
                await _service.Atualizar(prospect);

                if (!OperacaoValida())
                {
                    //_logger.LogWarning("Erro na validação da regra negocio");

                    return View(prospectViewModel);
                }

                mensagem = $"Projeto {prospect.IdPsp} editado com sucesso!";

                //_logger.LogInformation(mensagem);
            }

            return RedirectToAction(nameof(Index), new { mensagem });
        }


        //[ClaimsAuthorize("Prospect", "Excluir")]
        [HttpPost]
        [Route("excluir-projeto/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var prospect = _mapper.Map<ProspectViewModel>(await _context.ObterPorId(id));

            if (prospect == null)
                return NotFound();

            await _service.Remover(id);

            return Json(new { isValida = true, html = Helper.RenderRazorViewToString(this, "_Lista", _mapper.Map<IEnumerable<ProspectViewModel>>(await _context.ObterTodos()) ) });
        }


        private async Task<ProspectViewModel> PopularListas(ProspectViewModel prospect)
        {
            prospect.Categories = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.ObterTodos());
            prospect.Employees = _mapper.Map<IEnumerable<EmployeeViewModel>>(await _employeeRepository.ObterTodos());
            prospect.Customers = _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.ObterTodos());
            prospect.Companies = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.ObterTodos());
            
            return prospect;
        }
    }
}
