using AutoMapper;
using Dev.App.Extensions;
using Dev.App.ViewModels;
using Dev.Business.Interfaces;
using Dev.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev.App.Controllers
{
    [Route("clientes")]
    public class CustomersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISegmentRepository _segmentRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        public CustomersController(
            ISegmentRepository segmentRepository,
            ICustomerRepository customerRepository,
            ICustomerService customerService,
            IMapper mapper,
            INotifier notificador) : base(notificador)
        {
            _segmentRepository = segmentRepository;
            _customerRepository = customerRepository;
            _customerService = customerService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("buscar-clientes")]
        public IActionResult SearchCustomers(string term)
        {
            try 
            {
                var customers = _mapper.Map<IEnumerable<CustomerViewModel>>(_customerRepository.Buscar(x => x.Name.Contains(term.ToUpper()) || x.CNPJ.Contains(term)).Result);

                return Json(customers);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [ClaimsAuthorize("Customer", "Adicionar")]
        [Route("adicionar-atualizar-cliente")]
        public async Task<IActionResult> AddOrEdit()
        {
            var prospectViewModel = new ProspectViewModel();
            prospectViewModel.Customer = new CustomerViewModel();

            prospectViewModel = await PopularListaSegmentos(prospectViewModel);

            return PartialView("_AddOrEdit", prospectViewModel);
        }

        [ClaimsAuthorize("Customer", "Adicionar")]
        [Route("adicionar-atualizar-cliente")]
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(ProspectViewModel prospectViewModel)
        {
            prospectViewModel = await PopularListaSegmentos(prospectViewModel);

            ModelState.Remove("Name");
            ModelState.Remove("ProActive");
            ModelState.Remove("Competition");
            ModelState.Remove("NameCompetitors");
            ModelState.Remove("International");
            ModelState.Remove("Status");
            ModelState.Remove("Opening");
            ModelState.Remove("Type");
            ModelState.Remove("PhaseProspect");
            ModelState.Remove("CategoryId");
            ModelState.Remove("EmployeeId");
            ModelState.Remove("CustomerId");
            ModelState.Remove("CompanyId");

            if (!ModelState.IsValid)
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_AddOrEdit", prospectViewModel) });

            var customer = _mapper.Map<Customer>(prospectViewModel.Customer);

            await _customerService.Adicionar(customer);

            if (!OperacaoValida()) 
                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_AddOrEdit", prospectViewModel) });

            return Json(new { isValid = true, cliente = customer });
        }

        private async Task<ProspectViewModel> PopularListaSegmentos(ProspectViewModel prospect)
        {
            prospect.Customer.Segments = _mapper.Map<IEnumerable<SegmentViewModel>>(await _segmentRepository.ObterTodos());

            return prospect;
        }
    }
}
