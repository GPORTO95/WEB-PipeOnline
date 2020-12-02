using System;
using KissLog.AspNetCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.CloudListeners.Auth;

namespace Dev.App.Configuration
{
    public static class LogConfig
    {
        public static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
        {
            options.Options
                .AppendExceptionDetails((Exception ex) =>
                {
                    StringBuilder sb = new StringBuilder();

                    if (ex is System.NullReferenceException nullRefException)
                    {
                        sb.AppendLine("Important: check for null references");
                    }

                    return sb.ToString();
                });

            options.InternalLog = (message) =>
            {
                Debug.WriteLine(message);
            };

            RegisterKissLogListeners(options, configuration);
        }

        private static void RegisterKissLogListeners(IOptionsBuilder options, IConfiguration configuration)
        {
            options.Listeners.Add(new RequestLogsApiListener(new Application(
                configuration["KissLog.OrganizationId"],      
                configuration["KissLog.ApplicationId"])       
            )
            {
                ApiUrl = configuration["KissLog.ApiUrl"]      
            });
        }
    }
}
