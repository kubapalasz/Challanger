using System;
using Nancy.Hosting.Self;
using Serilog;

namespace GeekUp.Host
{
    public class HostService
    {
        private const string LocalAddress = "10.202.36.105";

        private NancyHost _nancyHost;
        private readonly int _port;

        public HostService(int port)
        {
            _port = port;
        }

        public void Start()
        {
            var url = string.Format("http://{0}:{1}/", LocalAddress, _port);

            _nancyHost = new NancyHost(new Uri(url));
            _nancyHost.Start();

            Log.Information("GeekUp.Host now listening to {url}.", url);
        }

        public void Stop()
        {
            _nancyHost.Stop();

            Log.Information("GeekUp.Host stopped. Good bye!");
        }
    }
}