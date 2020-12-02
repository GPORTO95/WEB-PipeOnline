using Dev.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Business.Interfaces
{
    public interface INotifier
    {
        bool TemNotificacao();
        List<Notification> ObterNotificacoes();
        void Handle(Notification notificacao);
    }
}
