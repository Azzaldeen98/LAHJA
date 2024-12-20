﻿
using Domain.Entities.Payment;
using Domain.Entities.Payment.Response;
using Domain.ShareData.Base;
using Domain.ShareData.Base.Auth;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.Models.Payment.Request;
using Infrastructure.Models.Payment.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Price.Request;
using Infrastructure.Models.Price.Response;
using Infrastructure.Nswag;


namespace Infrastructure.Mappings.Plans
{

    public class InfrastructureRemoteMappingConfig : AutoMapper.Profile
    {
        public InfrastructureRemoteMappingConfig()
        {

            /// Auth
            /// 
            CreateMap<AccessTokenResponse, AccessTokenResponseModel>().ReverseMap();
            CreateMap<RefreshRequestModel, RefreshRequest>().ReverseMap();
            //CreateMap<ConfirmationEmailModel, ConfirmationEmailRequest>().ReverseMap();
            CreateMap<ResendConfirmationEmailRequest, ResendConfirmationEmailModel>().ReverseMap();
            CreateMap<ResetPasswordRequest, ResetPasswordRequestModel>().ReverseMap();
         

            CreateMap<LoginRequestModel, LoginRequest>().ReverseMap();
            CreateMap<RegisterRequestModel,  RegisterRequest>()
                 .ForMember(dest => dest.FirsName, opt => opt.MapFrom(src => "string"))
                 .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => "string"))
                 .ForMember(dest => dest.ConfirmPassword, opt => opt.MapFrom(src => src.password))
                 .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => "string"))
                .ReverseMap();

            CreateMap<LoginResponseModel, AccessTokenResponse>().ReverseMap();

            CreateMap<ConfirmationEmailModel, ConfirmEmailRequest>().ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgetPasswordRequestModel>().ReverseMap();



            CreateMap<DeletedResponse, DeletedResponseModel>().ReverseMap();

            /// Price
            CreateMap<PriceCreate, PriceCreateRequestModel>().ReverseMap();
            CreateMap<PriceUpdate, PriceUpdateRequestModel>().ReverseMap();
            CreateMap<PriceResponse, PriceResponseModel>().ReverseMap();


            /// Plans


            /// Profile
            //CreateMap<ProfileResponseModel, >().ReverseMap();


            /// Payment
            CreateMap<PaymentCheckoutRequestModel, CheckoutOptions>().ReverseMap();
            CreateMap<PaymentCheckoutResponseModel, CheckoutResponse>().ReverseMap();
            CreateMap<SessionCreateModel, SessionCreate>().ReverseMap();



        }
    }
}