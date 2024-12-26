﻿using Infrastructure.Models.Plans;
using Domain.Entities.User;
using Infrastructure.Models.User;
using Infrastructure.DataSource.Seeds.Models;
using Domain.Entities.Auth.Response;
using Domain.Entities.Auth.Request;
using Infrastructure.Models.Profile.Response;
using Domain.ShareData.Base.Auth;
using Infrastructure.Models.Auth.Response;
using Domain.Entities.Payment;
using Infrastructure.Models.Payment.Request;
using Infrastructure.Models.Payment.Response;
using Domain.Entities.Payment.Response;
using Infrastructure.Models.BaseFolder.Response;
using Domain.ShareData.Base;
using Infrastructure.Models.Price.Response;
using Domain.Entities.Price.Response;
using Infrastructure.Models.Price.Request;
using Domain.Entities.Price.Request;
using Infrastructure.Models.Product.Response;
using Domain.Entities.Product.Response;
using Domain.Entities.Product.Request;
using Infrastructure.Models.Product.Request;
using Infrastructure.Models.Subscriptions.Request;
using Domain.Entities.Subscriptions.Response;
using Domain.Entities.Plans.Response;
using Infrastructure.Models.Setting.Request;
using Domain.Entities.Setting.Request;
using Infrastructure.Models.Setting.Response;
using Domain.Entities.Setting.Response;
using Infrastructure.Models.Billing.Request;
using Infrastructure.Models.Billing.Response;
using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
using Domain.Entities.Profile;
using Domain.Entities;
using Infrastructure.Models.Plans.Response;
using Infrastructure.Models.Profile.Request;


namespace Infrastructure.Mappings.Plans
{

    public class InfrastructureMappingConfig : AutoMapper.Profile
    {
        public InfrastructureMappingConfig()
        {



            /// Auth
            CreateMap<UserModel, RegisterRequestModel>().ReverseMap();
            CreateMap<UserModel, UserApp>().ReverseMap();
            CreateMap<LoginRequestModel, Domain.Entities.Auth.Request.LoginRequest>().ReverseMap();
            CreateMap<RegisterRequestModel, UserApp>().ReverseMap();
            CreateMap<RegisterRequestModel, Domain.Entities.Auth.Request.RegisterRequest>().ReverseMap();
            CreateMap<RegisterResponseModel, RegisterResponse> ().ReverseMap();
            CreateMap<LoginResponseModel, LoginResponse>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<LoginResponseModel, UserModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.userId))
            .ReverseMap();
            CreateMap<RegisterRequestModel, Domain.Entities.Auth.Request.RegisterRequest>().ReverseMap();


            CreateMap<AccessTokenResponseModel, AccessTokenResponse>().ReverseMap();
            CreateMap<RefreshRequestModel, RefreshRequest>().ReverseMap();
            CreateMap<ConfirmationEmailModel, ConfirmationEmail>().ReverseMap();
            CreateMap<ResendConfirmationEmail, ResendConfirmationEmailModel>().ReverseMap();
            CreateMap<ResetPasswordRequest, ResetPasswordRequestModel>().ReverseMap();
            CreateMap<ForgetPasswordRequest, ForgetPasswordRequestModel>().ReverseMap();
            CreateMap<ForgetPasswordResponse, ForgetPasswordResponseModel>().ReverseMap();
            /// Plans



            /// Profile 
            CreateMap<ProfileResponseModel, UserApp>().ReverseMap();
           

            /// Payment
            CreateMap<PaymentCheckoutRequestModel, PaymentCheckoutRequest>().ReverseMap();
            CreateMap<PaymentCheckoutResponseModel, PaymentCheckoutResponse>().ReverseMap();

            CreateMap<DeleteResponseModel, DeleteResponse>().ReverseMap();





            /// Price
            CreateMap<PriceResponseModel, PriceResponse>().ReverseMap();
            CreateMap<PriceCreateRequestModel,PriceCreate>().ReverseMap();
            CreateMap<PriceUpdateRequestModel,PriceUpdate>().ReverseMap();


            //// Product 

            CreateMap<ProductResponseModel, ProductResponse>().ReverseMap();
            CreateMap<ProductCreateModel, ProductCreate>().ReverseMap();
            CreateMap<ProductUpdateModel, ProductUpdate>().ReverseMap();
            CreateMap<ProductSearchRequestModel, ProductSearchRequest>().ReverseMap();


            //// Subscriptions 
            CreateMap<SubscriptionResponseModel, SubscriptionResponse>().ReverseMap();


            // Billing
            CreateMap<CardDetailsResponseModel,CardDetailsResponse>().ReverseMap();  
            CreateMap<BillingDetailsResponseModel,BillingDetailsResponse>().ReverseMap();  
            CreateMap<BillingDetailsResponseModel, BillingDetailsRequestModel>().ReverseMap();
            CreateMap<BillingDetailsRequestModel, BillingDetailsRequest>().ReverseMap();

            CreateMap<CardDetailsRequestModel, CardDetailsRequest>().ReverseMap();
            CreateMap<CardDetailsResponseModel, CardDetailsRequestModel>().ReverseMap();  
            CreateMap<CardDetailsResponseModel, CardDetailsResponse>().ReverseMap();  
  
        

            
            //// Settings 
            CreateMap<SettingResponseModel,SettingResponse>().ReverseMap();
            CreateMap<SettingUpdateModel, SettingUpdate>().ReverseMap();
    
            
            
            
            //// Profile
            CreateMap<ProfileResponseModel, ProfileResponse>()
                 .ForMember(dest => dest.CreditCards, opt => opt.Ignore())
                 .ForMember(dest => dest.SubscriptionsPlans, opt => opt.Ignore())
                 .ForMember(dest => dest.BillingDetails, opt => opt.Ignore())
                 .ReverseMap();   
            CreateMap<UserSubscriptionPlanModel, UserSubscriptionPlan>().ReverseMap();   
            CreateMap<ProfileRequestModel, ProfileRequest>().ReverseMap();   

           


        }
    }
}
