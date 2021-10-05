﻿
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CMSWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            host.Run();
           
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
