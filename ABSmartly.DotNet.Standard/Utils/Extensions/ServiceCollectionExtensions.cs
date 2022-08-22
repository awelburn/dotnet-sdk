﻿using System;
using ABSmartlySdk.DefaultServiceImplementations;
using ABSmartlySdk.Temp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ABSmartlySdk.Utils.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddABSmartly(this IServiceCollection services, IOptions<ClientConfiguration> clientConfiguration)
    {

    }

    public static void AddABSmartly(this IServiceCollection services, Action<ABSmartlyConfig> options = null, ServiceLifetime? lifeTime = null)
    {
        //IConfiguration Configuration = null;

        //var config = Configuration.GetSection("ABSmartlyConfig");
        //config.

        //services.Configure<ClientConfiguration>();

        Add(services, options, lifeTime);


    }

    private static void Add(IServiceCollection services, Action<ABSmartlyConfig> options = null, ServiceLifetime? lifeTime = null)
    {
        services.AddHttpClient<ABSmartly>(DefaultHttpClient.ABSmartyHttpClientName, o =>
        {
            // Todo: add a base address??
            //o.BaseAddress = new Uri("");
        });

        if (lifeTime is null)
            lifeTime = ServiceLifetime.Singleton;

        if (lifeTime is ServiceLifetime.Singleton)
            services.AddSingleton<ABSmartly>();

        else if (lifeTime is ServiceLifetime.Scoped)
            services.AddScoped<ABSmartly>();

        else if (lifeTime is ServiceLifetime.Transient)
            services.AddTransient<ABSmartly>();

        if (options is not null)
            services.Configure(options);

        //var absmartly = ABSmartly.Create(null);
        //return absmartly;
    }
}