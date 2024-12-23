﻿using Application.Services.Plans;
using AutoMapper;
using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
using Domain.Wrapper;
using Infrastructure.Nswag;
using LAHJA.Data.UI.Components.Payment.BillingContact;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LAHJA.Data.UI.Templates.CreditCard
{

    public class DataBuildCreditCardBase {

        public string CreditCardId  { get; set; }
        public string Email  { get; set; }

        public string SuccessUrl { get; set; } = "https://asg.tryasp.net/swagger/index.html";
        public string CancelUrl { get; set; } = "https://asg.tryasp.net/api/Details";
    }


    public interface IBuilderCreditCardComponent<T> : IBuilderComponents<T>
    {

        public Func<T, Task> SubmitCreateCreditCardDetails { get; set; }
        public Func<T, Task> SubmitUpdateCreditCardDetails { get; set; }
        public Func<T, Task> SubmitDeleteCreditCardDetails { get; set; }
  


    }



    public interface IBuilderCreditCardApi<T> : IBuilderApi<T>
    {


        //Task<Result<List<InputCategory>>> OnInitialize();



          Task<Result<List<BillingContact>>> GetCreditCardDetails(T data);
          Task<Result<CardDetailsResponse>> CreateCreditCardDetails(T data);
          Task<Result<CardDetailsResponse>> UpdateCreditCardDetails(T data);
          Task<Result<DeletedResponse>> DeleteCreditCardDetails(T data);


    }

    public abstract class BuilderCreditCardApi<T, E> : BuilderApi<T, E>, IBuilderCreditCardApi<E>
    {

        public BuilderCreditCardApi(IMapper mapper, T service) : base(mapper, service)
        {

        }

        //public abstract Task<Result<List<InputCategory>>> OnInitialize();

        public abstract Task<Result<List<BillingContact>>> GetCreditCardDetails(E data);
        public abstract Task<Result<CardDetailsResponse>> CreateCreditCardDetails(E data);
        public abstract Task<Result<CardDetailsResponse>> UpdateCreditCardDetails(E data);
        public abstract Task<Result<DeletedResponse>> DeleteCreditCardDetails(E data);




    }
    public class BuilderCreditCardComponent<T> : IBuilderCreditCardComponent<T>
    {
        public Func<T, Task> SubmitCreateCreditCardDetails { get; set; }
        public Func<T, Task> SubmitUpdateCreditCardDetails { get; set; }
        public Func<T, Task> SubmitDeleteCreditCardDetails { get; set; }
        


    }


    public class TemplateCreditCardShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderCreditCardApi<E> builderApi;
        private readonly IBuilderCreditCardComponent<E> builderComponents;
        public IBuilderCreditCardComponent<E> BuilderComponents { get => builderComponents; }
        public TemplateCreditCardShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                IBuilderCreditCardComponent<E> builderComponents,
                NavigationManager navigation,
                IDialogService dialogService,
                ISnackbar snackbar


            ) : base(mapper, AuthService, client)
        {



            builderComponents = new BuilderCreditCardComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;


        }

    }

     
    public class BuilderCreditCardApiClient : BuilderCreditCardApi<CreditCardClientService, DataBuildCreditCardBase>, IBuilderCreditCardApi<DataBuildCreditCardBase>
    {
        public BuilderCreditCardApiClient(IMapper mapper, CreditCardClientService service) : base(mapper, service)
        {
        }


        public async override Task<Result<CardDetailsResponse>> CreateCreditCardDetails(DataBuildCreditCardBase data)
        {
            var model = Mapper.Map<CardDetailsRequest>(data);
            var res = await Service.UpdateAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<CardDetailsResponse>(res.Data);
                    return Result<CardDetailsResponse>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<CardDetailsResponse>.Fail();
                }
            }
            else
            {
                return Result<CardDetailsResponse>.Fail(res.Messages);
            }
        }


        public async override Task<Result<DeletedResponse>> DeleteCreditCardDetails(DataBuildCreditCardBase data)
        {
            var model = Mapper.Map<CardDetailsRequest>(data);
            var res = await Service.DeleteAsync(data?.CreditCardId);
            if (res.Succeeded)
            {
                try
                { 
                    return Result<DeletedResponse>.Success();

                }
                catch (Exception e)
                {
                    return Result<DeletedResponse>.Fail();
                }
            }
            else
            {
                return Result<DeletedResponse>.Fail(res.Messages);
            }
        }

        public override async Task<Result<List<BillingContact>>> GetCreditCardDetails(DataBuildCreditCardBase data)
        {

 
            var res = await Service.GetSubscriptionCreditCardsAsync();
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<List<BillingContact>>(res.Data);
                    return Result<List<BillingContact>>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<List<BillingContact>>.Fail();
                }
            }
            else
            {
                return Result<List<BillingContact>>.Fail(res.Messages);
            }
        }

        public async override Task<Result<CardDetailsResponse>> UpdateCreditCardDetails(DataBuildCreditCardBase data)
        {
            var model = Mapper.Map<CardDetailsRequest>(data);
            var res = await Service.UpdateAsync(model);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<CardDetailsResponse>(res.Data);
                    return Result<CardDetailsResponse>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<CardDetailsResponse>.Fail();
                }
            }
            else
            {
                return Result<CardDetailsResponse>.Fail(res.Messages);
            }
        }
    }


    public class TemplateCreditCard : TemplateCreditCardShare<CreditCardClientService, DataBuildCreditCardBase>
    {

   
        public List<string> Errors { get => _errors; }

   


        public TemplateCreditCard(
            IMapper mapper,
            AuthService AuthService,
            CreditCardClientService client,
            IBuilderCreditCardComponent<DataBuildCreditCardBase> builderComponents,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            //this.BuilderComponents.SubmitCreditCardDetailsLink = getCreditCardDetailsUrlCreditCards;
       

            this.builderApi = new BuilderCreditCardApiClient(mapper, client);

            //Task.FromResult(OnInitialize());

        }



        public async Task<Result<List<BillingContact>>> GetCreditCardDetails()
        {
      

               return await builderApi.GetCreditCardDetails(new DataBuildCreditCardBase());

        }

        public async Task onCreateCreditCardDetails(DataBuildCreditCardBase DataBuildCreditCardBase)
        {

             await builderApi.CreateCreditCardDetails(DataBuildCreditCardBase);

        }

        public async Task oUpdateCreditCardDetails(DataBuildCreditCardBase DataBuildCreditCardBase)
        {

            await builderApi.UpdateCreditCardDetails(DataBuildCreditCardBase);

        }
        public async Task onDeleteCreditCardDetails(DataBuildCreditCardBase DataBuildCreditCardBase)
        {

            await builderApi.DeleteCreditCardDetails(DataBuildCreditCardBase);

        }


        


    }

}