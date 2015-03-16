namespace NancySelfHosting
{
    using System;
    using Nancy.Hosting.Self;

    using System.Diagnostics;

    class Program
    {
        static void Main()
        {
            String myTeamWebServerAddress = "http://10.202.36.57/"; //Your machin's IP address
            
            var nancyHost = new NancyHost(new Uri(myTeamWebServerAddress));

            nancyHost.Start();

            Console.WriteLine("Nancy now listening - navigating to "+myTeamWebServerAddress+". Press enter to stop");
            Process.Start(myTeamWebServerAddress);
            Console.ReadKey();

            nancyHost.Stop();

            Console.WriteLine("Stopped. Good bye!");
        }
    }
}
