using System;
using CommandLine;
using Serilog;
using Topshelf;

namespace GeekUp.Host
{
    public class Program
    {
        private const string SeqUrl = "http://localhost:5341/";
        private const string SeqApiKey = "YOUR KEY HERE";

        private sealed class Options
        {
            [Option('p', "port", DefaultValue = 3003)]
            public int Port { get; set; }

            [Option('s', "selfhost", DefaultValue = false)]
            public bool SelfHost { get; set; }
        }

        public static void Main(string[] args)
        {
            var options = new Options();
            Parser.Default.ParseArguments(args, options);
            
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("Application", "GeekUp")
                .Enrich.WithProperty("Options", new { options.Port, options.SelfHost })
                .WriteTo.Seq(SeqUrl, apiKey: SeqApiKey)
                .WriteTo.ColoredConsole()
                .CreateLogger();

            if (options.SelfHost)
            {
                Run(options.Port);
            }
            else
            {
                RunAsService(options.Port);
            }
        }

        private static void Run(int port)
        {
            var service = new HostService(port);
            service.Start();

            Console.ReadKey();

            service.Stop();
        }

        private static void RunAsService(int port)
        {
            HostFactory.Run(x =>
            {
                x.Service<HostService>(s =>
                {
                    s.ConstructUsing(name => new HostService(port));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("GeekUp Host");
                x.SetDisplayName("GeekUp Host");
                x.SetServiceName("GeekUp.Host");
            });
        }
    }
}
