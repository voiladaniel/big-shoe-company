// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The Program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Show.Company
{
    using System.IO;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method (entry point) creating the web host builder.
        /// </summary>
        /// <param name="args">The list of arguments.</param>
        public static void Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args);
            var host = builder.Build();
            host.Run();
        }

        /// <summary>
        /// The web host builder method.
        /// </summary>
        /// <param name="args">The list of arguments.</param>
        /// <returns>The static web host builder instance.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .Build())
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddFilter("Microsoft", LogLevel.Warning)
                        .AddFilter("System", LogLevel.Warning);
                    logging.SetMinimumLevel(LogLevel.Trace);
                    logging.AddLog4Net();
                });
    }
}
