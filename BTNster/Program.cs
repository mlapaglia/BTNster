﻿namespace BTNster
{
    using System;
    using Nancy.Hosting.Self;
    using System.Threading;


    public class Program
    {
        static void Main(string[] args)
        {
            StartWebServer();
        }

        static void StartWebServer()
        {
            var uri = new Uri("http://localhost:3579");

            HostConfiguration hostConfigs = new HostConfiguration();
            hostConfigs.UrlReservations.CreateAutomatically = true;

            using (var host = new NancyHost(hostConfigs, uri))
            {
                host.Start();

                Console.WriteLine("Your application is running on " + uri);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }
}
