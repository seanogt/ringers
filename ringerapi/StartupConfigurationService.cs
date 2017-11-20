using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ringerapi
{
    internal class StartupConfigurationService : IStartUpConfigurationService
    {
        Func<List<Player>> _noddyRingerList = () => new List<Player>() { new Player(1, "Sean") };

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) { }

        public virtual void ConfigureEnvironment(IHostingEnvironment env) { }

        public void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton(typeof(Func<List<Player>>), _noddyRingerList);
        }
    }
}
