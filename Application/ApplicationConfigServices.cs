using Application.Services.Auth;
using Application.Services.Plans;
using Application.Services.Profile;
using Application.Services.Prroduct;
using Application.Services.Subscriptions;
using Application.UseCase;
using Application.UseCase.Auth;
using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Infrastructure.Mappings.Plans;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ApplicationConfigServices
    {
        public static void InstallApplicationConfigServices(this IServiceCollection serviceCollection)
        {

            InstallMapping(serviceCollection);
            InstallUsaCases(serviceCollection);
            InstallServices(serviceCollection);

        }


       private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ApplicationMappingConfig));
        }

        private static void InstallUsaCases(this IServiceCollection serviceCollection)
        {
            /// Auth
            serviceCollection.AddScoped<LoginUseCase>();
            serviceCollection.AddScoped<RegisterUseCase>();
            serviceCollection.AddScoped<ForgetPasswordUseCase>();
            serviceCollection.AddScoped<ResetPasswordUseCase>();
            serviceCollection.AddScoped<ConfirmationEmailUseCase>();
            serviceCollection.AddScoped<ReSendConfirmationEmailUseCase>();
            serviceCollection.AddScoped<RefreshTokinUseCase>();
            serviceCollection.AddScoped<LogoutUseCase>();

            /// Plans
            serviceCollection.AddScoped<GetAllContainersPlansUseCase>();
            serviceCollection.AddScoped<GetPlansGroupUseCase>();
            serviceCollection.AddScoped<GetAllPlansUseCase>();
            serviceCollection.AddScoped<PlanUpdateUseCase>();
            serviceCollection.AddScoped<PlanCreateUseCase>();
            serviceCollection.AddScoped<GetPlanByIdUseCase>();
            serviceCollection.AddScoped<GetPlanInfoByIdUseCase>();
            serviceCollection.AddScoped<GetAllPlansContainersUseCase>();
            serviceCollection.AddScoped<GetSubscriptionPlansUseCase>();
            serviceCollection.AddScoped<GetOneSubscriptionPlanUseCase>();
            serviceCollection.AddScoped<GetSubscriptionPlanFeaturesUseCase>();
            serviceCollection.AddScoped<GetAllSubscriptionsPlansUseCase>();
         


            /// Profile
            serviceCollection.AddScoped<GetProfileUseCase>();


            /// Payment
            serviceCollection.AddScoped<GetPaymentCheckOutUseCase>();
            serviceCollection.AddScoped<GetPaymentCheckOutManageUseCase>();

               
            /// Price
            serviceCollection.AddScoped<SearchPriceUseCase>();
            serviceCollection.AddScoped<DeletePriceUseCase>();
            serviceCollection.AddScoped<CreatePriceUseCase>();
            serviceCollection.AddScoped<UpdatePriceUseCase>();


            /// Product
            serviceCollection.AddScoped<CreateProductUseCase>();
            serviceCollection.AddScoped<UpdateProductUseCase>();
            serviceCollection.AddScoped<DeleteProductUseCase>();
            serviceCollection.AddScoped<GetAllProductsUseCase>();
            serviceCollection.AddScoped<SearchProductUseCase>();




            /// Settings
            //serviceCollection.AddScoped<SearchPriceUseCase>();


            /// Subscription
            serviceCollection.AddScoped<PauseSubscriptionUseCase>();
            serviceCollection.AddScoped<DeleteSubscriptionUseCase>();
            serviceCollection.AddScoped<ResumeSubscriptionUseCase>();
            serviceCollection.AddScoped<GetAllSubscriptionsUseCase>();



        }

        private static void InstallServices(this IServiceCollection serviceCollection)
        {
           
            serviceCollection.AddScoped<PlansService>();
            serviceCollection.AddScoped<WebAuthService>();
            serviceCollection.AddScoped<ProfileService>();
            serviceCollection.AddScoped<PaymentService>();
            serviceCollection.AddScoped<PriceService>();
            serviceCollection.AddScoped<ProductService>();
            serviceCollection.AddScoped<SubscriptionService>();

        }

    }
}
