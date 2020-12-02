using Dev.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dev.App.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotifier _notificador;

        public SummaryViewComponent(INotifier notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());

            notificacoes.ForEach(x => ViewData.ModelState.AddModelError(string.Empty, x.Mensagem));

            return View();
        }
    }
}
