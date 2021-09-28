// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The Startup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Show.Company
{
    using Big.Shoe.Company.Data.Settings;
    using Big.Shoe.Company.Impl.Castle;

    using Castle.Facilities.AspNetCore;
    using Castle.Windsor;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The Service Startup Configuration.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The container.
        /// </summary>
        private static readonly WindsorContainer Container = new WindsorContainer();

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            //// Retrieve AppSettings.json Application section, and map it to a POCO, and make it available in the container
            var appSettings = this.Configuration.GetSection("ApplicationSettings").Get<AppSettingsPoco>();

            Container.AddFacility<AspNetCoreFacility>(f => f.CrossWiresInto(services));

            services.AddControllers()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder => builder
                        .WithOrigins(appSettings.CorsAllowedOrigins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("MarketingManager", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Marketing API" });
            });
            services.AddHttpClient();
            services.AddWindsor(Container);

            Container.Install(new Installer(appSettings));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        /// /// <param name="loggerFactory">
        /// The logger factory.
        /// </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Container.GetFacility<AspNetCoreFacility>().RegistersMiddlewareInto(app);
            loggerFactory.AddLog4Net();
            app.UseCors("CorsPolicy");

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/MarketingManager/swagger.json", "Marketing API");
            });
        }
    }
}
