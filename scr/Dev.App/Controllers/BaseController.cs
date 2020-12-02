using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dev.App.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotifier _notificador;

        public BaseController(INotifier notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}