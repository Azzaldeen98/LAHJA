﻿using Domain.Repository.Auth;
using Domain.Repository.Billing;
using Domain.Repository.Payment;
using Domain.Repository.Plans;
using Domain.Repository.Price;
using Domain.Repository.Product;
using Domain.Repository.Profile;
using Domain.Repository.Setting;
using Domain.Repository.Subscriptions;
using Domain.Repository.Users;
using Infrastructure.DataSource;
using Infrastructure.DataSource.ApiClient.Auth;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClient.Billing;
using Infrastructure.DataSource.ApiClient.Payment;
using Infrastructure.DataSource.ApiClient.Plans;
using Infrastructure.DataSource.ApiClient.Profile;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Mappings.Plans;
using Infrastructure.Repository.Auth;
using Infrastructure.Repository.Plans;
using Infrastructure.Repository.Price;
using Infrastructure.Repository.Product;
using Infrastructure.Repository.Setting;
using Infrastructure.Repository.Subscription;
using Infrastructure.Repository.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureConfigServices
    {
        public static void InstallInfrastructureConfigServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            InstallConfiguration(serviceCollection,configuration);
            InstallApiClients(serviceCollection);
            InstallSeeds(serviceCollection);
            InstallMapping(serviceCollection);
            InstallRepositories(serviceCollection);
            InstallControls(serviceCollection);
        
        }

        private static void InstallConfiguration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var baseUrl = configuration.GetSection("BaseUrl").Get<BaseUrl>();
            serviceCollection.AddSingleton<BaseUrl>(baseUrl);

            serviceCollection.AddHttpClient("ApiClient", client => { client.BaseAddress = new Uri(baseUrl.Api); });

            serviceCollection.AddScoped<ClientFactory>();
            //serviceCollection.AddScoped<ITokenProvider, TokenProvider>();

        }
        private static void InstallControls(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<AuthControl>();
        }
        private static void InstallApiClients(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped(typeof(IBuildApiClient<>), typeof(BuildApiClient<>));
            serviceCollection.AddScoped<AuthApiClient>();
            serviceCollection.AddScoped<PlansApiClient>();
            serviceCollection.AddScoped<PaymentApiClient>();
            serviceCollection.AddScoped<PriceApiClient>();
            serviceCollection.AddScoped<ProductApiClient>();
            serviceCollection.AddScoped<SubscriptionsApiClient>();
            serviceCollection.AddScoped<SettingsApiClient>();
            serviceCollection.AddScoped<ProfileApiClient>();
            serviceCollection.AddScoped<BillingApiClient>();
        }
        private static void InstallSeeds(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<SeedsProfile>();
            serviceCollection.AddSingleton<SeedsUsers>();
            serviceCollection.AddSingleton<SeedsPlans>();
            serviceCollection.AddSingleton<SeedsPlansContainers>();
            serviceCollection.AddSingleton<SeedsBillings>();
            serviceCollection.AddSingleton<SeedsCreditCards>();
         
           

       
        }

        private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(InfrastructureMappingConfig));
            serviceCollection.AddAutoMapper(typeof(PlansMappingConfig));
            serviceCollection.AddAutoMapper(typeof(PlansRemoteMappingConfig));
            serviceCollection.AddAutoMapper(typeof(InfrastructureRemoteMappingConfig));
        }

        private static void InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPlansContainerRepository, PlansContainerRepository>();
            serviceCollection.AddScoped<IPaymentRepository, PaymentRepository>();
            serviceCollection.AddScoped<IPlansRepository,PlansRepository>();
            serviceCollection.AddScoped<IUsersRepository,UsersRepository>();
            serviceCollection.AddScoped<IAuthRepository,AuthRepository>();
            serviceCollection.AddScoped<IProfileRepository, ProfileRepository>();
            serviceCollection.AddScoped<IPriceRepository, PriceRepository>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<ISubscriptionsRepository, SubscriptionsRepository>();
            serviceCollection.AddScoped<ISettingRepository, SettingRepository>();
            serviceCollection.AddScoped<IBillingRepository, BillingRepository>();
        }    
      
    }
}
