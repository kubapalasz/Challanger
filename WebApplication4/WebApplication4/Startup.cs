using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApplication4.Startup))]

namespace WebApplication4
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                var datasent = context.Request.QueryString.ToString().Substring(1); //substring ignores the '?' character
                LogRequest(datasent);
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("request says: " + datasent);
            });
        }

        private static void LogRequest(string datasent)
        {
            try
            {
                var filename = HttpRuntime.AppDomainAppPath + "/requests.txt";
                using (var stream = File.AppendText(filename))
                {
                    stream.Write(datasent);
                    stream.WriteLine();
                }
            }
            catch
            {
                //swallow
            }
        }
    }
}