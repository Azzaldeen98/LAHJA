﻿using Domain.Entities.Plans.Response;
using LAHJA.Data.UI.Components.Base;
using Domain.Entities.Auth.Request;
using LAHJA.Data.UI.Components.Category;
using LAHJA.Data.UI.Templates.Payment;
using Domain.Entities.Payment;
using LAHJA.Data.UI.Components.Plan;
using LAHJA.Data.UI.Components.Payment.DataBuildBillingBase;
using Domain.Entities.Billing.Response;
using LAHJA.Data.UI.Components.ProFileModel;
using Domain.Entities.Profile;
using LAHJA.Data.UI.Components.Payment.CreditCard;
using Domain.Entities.Billing.Request;

namespace LAHJA.Mappings
{
    public class LAHJAMappingConfig : AutoMapper.Profile
    {

        public LAHJAMappingConfig()
        {

        
     
          
            CreateMap<LoginRequest, VitsModel.Auth.LoginRequest>().ReverseMap();
            CreateMap<RegisterRequest, VitsModel.Auth.RegisterRequest>().ReverseMap();
            //CreateMap<PlansContainer, InputCategory>().ReverseMap();

     

            //CreateMap<PlansGroupResponse,PlansFeture>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src=>src.ProductName))
            //    .ForMember(dest => dest.Services, opt => opt.Ignore())
            //    .ForMember(dest => dest.numberOfServices, opt => opt.Ignore())
            //    .ReverseMap();

            //CreateMap<PlanSubscriptionFeaturesResponse, Service>()
            //    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => (decimal)src.Amount))
            //    .ReverseMap();
            //CreateMap<PlanTechnicalFeaturesResponse, NumberOfService>().ReverseMap();

            CreateMap<PlansGroupResponse, PlanInfoResponse>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
           .ReverseMap();


            CreateMap<PlanSubscriptionFeaturesResponse, PlanTechnicalServiceResponse>()
                .ForMember(dest => dest.TechnicalServiceFeatures, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<PlanTechnicalFeaturesResponse, PlanQuantitativeFeatureResponse>().ReverseMap();




            CreateMap<PlanInfoResponse, PlanInfo>()
                .ForMember(dest => dest.PlanDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TechnologyServices, opt => opt.Ignore())
                .ForMember(dest => dest.ServiceDetailsList, opt => opt.Ignore())
                .ReverseMap();          
            
            
            CreateMap<PlanTechnicalServiceResponse, TechnologyService>()
                .ForMember(dest => dest.TechnicalServices, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<PlanQuantitativeFeatureResponse, DigitalService>()
             .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price))
           .ReverseMap();
            
            
            CreateMap<DataBuildAuthBase, LoginRequest>().ReverseMap();
            CreateMap<DataBuildAuthBase, RegisterRequest>().ReverseMap();
            CreateMap<DataBuildAuthBase, ForgetPasswordRequest>().ReverseMap();
            CreateMap<DataBuildAuthBase, ResendConfirmationEmail>().ReverseMap();
            CreateMap<DataBuildAuthBase, ResetPasswordRequest>()
                 .ForMember(dest => dest.NewPassword, opt => opt.MapFrom(src => src.Password))
                 .ForMember(dest => dest.ResetCode, opt => opt.MapFrom(src => src.Code))
                .ReverseMap();
            CreateMap<DataBuildAuthBase, ConfirmationEmail>()
                .ForMember(dest => dest.ChangedEmail, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
            //CreateMap<DataBuildAuthBase, RegisterRequest>().ReverseMap();

          

            /// Plans
            CreateMap<ContainerPlans, CategoryComponent>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ReverseMap();
            CreateMap<PlanFeature, DigitalService>()
                  .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price))
                .ReverseMap();
            CreateMap<PlanFeature, TechnologyService>()
                  .ForMember(dest => dest.TechnicalServices, opt => opt.Ignore())
                .ReverseMap();
             CreateMap<SubscriptionPlan, SubscriptionPlanInfo>().ReverseMap();
             CreateMap<PlanFeature, FeaturePlanInfo>().ReverseMap();


            /// Payment
            
            CreateMap<PaymentCheckoutRequest, DataBuildPaymentBase>().ReverseMap();

            /// Billing

            CreateMap<BillingDetailsResponse, DataBuildBillingBase>().ReverseMap();
            CreateMap<DataBuildBillingBase, BillingDetailsRequest>().ReverseMap();



            ///  CreditCard
            CreateMap<CardDetailsResponse, CardDetails>().ReverseMap();


            /// Profile

             CreateMap<ProfileResponse, DataBuildUserProfile>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image))
                .ReverseMap();   
            
            CreateMap<ProfileRequest, DataBuildUserProfile>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image))
                .ReverseMap();
            

            //.ForMember(dest => dest.ServiceDetailsList, opt => opt.MapFrom(src => src.Features
            //    .Where(feature => feature.IsFixed==true) 
            //    .Select(feature => new TechnologyService
            //    {
            //        Name = feature.Name,
            //        Description = feature.Description,
            //        Active= feature.Active,
            //        Id= feature.Id,
            //        TechnicalServices= null,

            //    }).ToList())) 
            //.ForMember(dest => dest.TechnologyServices, opt => opt.MapFrom(src => src.Features
            //    .Where(feature => !feature.IsFixed==false) 
            //    .Select(feature => new TechnologyService
            //    {
            //        Name = feature.Name,
            //        Description = feature.Description,
            //        Active = feature.Active,
            //        Id = feature.Id,
            //        TechnicalServices = null,
            //    }).ToList())) 
            //.ReverseMap();




            //CreateMap<TechnologyService, NumberOfService>().ReverseMap();
        }
    }
}