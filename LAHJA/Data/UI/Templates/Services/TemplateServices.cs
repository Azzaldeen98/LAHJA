using AutoMapper;
using Domain.Entities.Event.Response;
using Domain.Entities.Request.Response;
using Domain.Entities.Service.Request;
using Domain.Entities.Service.Response;
using Domain.ShareData.Base;
using Domain.ShareData.Base.Request;
using Domain.Wrapper;
using LAHJA.ApiClient.Models;
using LAHJA.ApplicationLayer.Service;
using LAHJA.ApplicationLayer.Subscription;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;


namespace LAHJA.Data.UI.Templates.Services
{

    public class DataBuildServiceBase
    {
     
        public string ServiceId {  get; set; }
        public string Text {  get; set; }
        public string Token {  get; set; }
        public string? ModelGateway { get; set; }
        public string? ModelAi { get; set; }
        public string? URL { get; set; }
        public string? Method { get; set; }
        public string? TagId { get; set; }
        public long NumberRequests { get; set; }
        public long CurrentNumberRequests { get; set; }
        public bool Allowed { get; set; }

    }



    public interface IBuilderServicesComponent<T> : IBuilderComponents<T>
    {
        Func<T, Task> SubmitGetOne { get; set; }
        Func<T, Task> SubmitGetAll { get; set; }
        Func<T, Task> SubmitCreate { get; set; }
        Func<T, Task> SubmitDelete { get; set; }
        Func<T, Task> SubmitUpdate { get; set; }
        Func<T, Task> SubmitText2Text { get; set; }
        Func<T, Task> SubmitText2Speech { get; set; }
        Func<T, Task> SubmitVoiceBot { get; set; }
    }

    public class BuilderServicesComponent<T> : IBuilderServicesComponent<T>
    {


        public Func<T, Task> SubmitGetOne { get; set; }
        public Func<T, Task> SubmitGetAll { get; set; }
        public Func<T, Task> SubmitCreate { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }
        public Func<T, Task> SubmitText2Text { get; set; }
        public Func<T, Task> SubmitText2Speech { get; set; }
        public Func<T, Task> SubmitVoiceBot { get; set; }

    }
    public interface IBuilderServicesApi<T> : IBuilderApi<T>
    {
        Task<Result<ServiceResponse>> GetOneAsync(T id);
        Task<Result<List<ServiceResponse>>> GetAllAsync();
        Task<Result<ServiceResponse>> CreateAsync(T data);
        Task<Result<DeleteResponse>> DeleteAsync(T data);
        Task<Result<ServiceResponse>> UpdateAsync(T data);
        Task<Result<ServiceAIResponse>> Text2Text(T data);
        Task<Result<ServiceAIResponse>> Text2Speech(T data);
        Task<Result<ServiceAIResponse>> VoiceBot(T data);
    }

    public interface IBuilderRequestApi<T> : IBuilderApi<T>
    {
        Task<Result<RequestAllowed>> AllowedAsync(T data);
        Task<Result<List<RequestResponse>>> GetAllRequestAsync();
        Task<Result<RequestResponse>> CreateRequestAsync(T data);
        Task<Result<DeleteResponse>> DeleteRequestAsync(T data);
        Task<Result<RequestResponse>> UpdateRequestAsync(T data);
        Task<Result<EventResponse>> CreateEventAsync(T data);
        Task<Result<EventResponse>> ResultRequestAsync(T data);
     
    }

    public abstract class BuilderServicesApi<T, E> : BuilderApi<T, E>, IBuilderServicesApi<E>, IBuilderRequestApi<E>
    {
        public BuilderServicesApi(IMapper mapper, T service) : base(mapper, service) { }

        public abstract Task<Result<ServiceResponse>> CreateAsync(E data);
        public abstract Task<Result<DeleteResponse>> DeleteAsync(E dataId);
        public abstract Task<Result<List<ServiceResponse>>> GetAllAsync();
        public abstract Task<Result<ServiceResponse>> GetOneAsync(E id);
        public abstract Task<Result<ServiceResponse>> UpdateAsync(E data);
        public abstract Task<Result<ServiceAIResponse>> Text2Text(E data);
        public abstract Task<Result<ServiceAIResponse>> Text2Speech(E data);
        public abstract Task<Result<ServiceAIResponse>> VoiceBot(E data);

        public abstract Task<Result<RequestAllowed>> AllowedAsync(E data);

        public abstract Task<Result<List<RequestResponse>>>  GetAllRequestAsync();


        public abstract Task<Result<RequestResponse>>  CreateRequestAsync(E data);



        public abstract Task<Result<RequestResponse>> UpdateRequestAsync(E data);


        public abstract  Task<Result<EventResponse>> CreateEventAsync(E data);


        public abstract Task<Result<EventResponse>> ResultRequestAsync(E data);

        public abstract Task<Result<DeleteResponse>> DeleteRequestAsync(E data);
       
    }

    public class BuilderServiceApiClient : BuilderServicesApi<LAHJAClientService, DataBuildServiceBase>, IBuilderServicesApi<DataBuildServiceBase>
    {
        public BuilderServiceApiClient(IMapper mapper, LAHJAClientService service) : base(mapper, service) { }

        public override async Task<Result<ServiceResponse>> CreateAsync(DataBuildServiceBase data)
        {
            var model = Mapper.Map<ServiceRequest>(data);
            return await Service.CreateAsync(model);
        }

        //public override async Task<Result<DeleteResponse>> DeleteAsync(DataBuildServiceBase data)
        //{
        //    return await Service.DeleteAsync(data.ServiceId);
        //}

        public override async Task<Result<List<ServiceResponse>>> GetAllAsync()
        {
            return await Service.GetAllAsync();
        }

 

        //public override async Task<Result<ServiceResponse>> UpdateAsync(DataBuildServiceBase data)
        //{
        //    var model = Mapper.Map<ServiceRequest>(data);
        //    return await Service.UpdateAsync(model);
        //}    
        public override async Task<Result<ServiceResponse>> GetOneAsync(DataBuildServiceBase data)
        {
          
            return await Service.GetOneAsync(data.ServiceId);
        }



        public override async Task<Result<ServiceAIResponse>> Text2Text(DataBuildServiceBase data)
        {
            var map=Mapper.Map<Data.UI.Models.QueryRequestTextToText>(data);
            return await Service.Text2TextAsync(map);
        }

        public override async Task<Result<ServiceAIResponse>> Text2Speech(DataBuildServiceBase data)
        {
            var map = Mapper.Map<Data.UI.Models.QueryRequestTextToSpeech>(data);
            return await Service.Text2SpeechAsync(map);
        }

        public override async Task<Result<ServiceAIResponse>> VoiceBot(DataBuildServiceBase data)
        {
            var map = Mapper.Map<QueryRequest>(data);
            return await Service.VoiceBotAsync(map);
        }

        public override Task<Result<RequestAllowed>> AllowedAsync(DataBuildServiceBase data)
        {
            throw new NotImplementedException();
        }

        public override Task<Result<List<RequestResponse>>> GetAllRequestAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Result<RequestResponse>> CreateRequestAsync(DataBuildServiceBase data)
        {
            throw new NotImplementedException();
        }

        public override Task<Result<RequestResponse>> UpdateRequestAsync(DataBuildServiceBase data)
        {
            throw new NotImplementedException();
        }

        public override Task<Result<EventResponse>> CreateEventAsync(DataBuildServiceBase data)
        {
            throw new NotImplementedException();
        }

        public override Task<Result<EventResponse>> ResultRequestAsync(DataBuildServiceBase data)
        {
            throw new NotImplementedException();
        }

        public override Task<Result<DeleteResponse>> DeleteRequestAsync(DataBuildServiceBase data)
        {
            throw new NotImplementedException();
        }

        public override Task<Result<DeleteResponse>> DeleteAsync(DataBuildServiceBase dataId)
        {
            throw new NotImplementedException();
        }

        public override Task<Result<ServiceResponse>> UpdateAsync(DataBuildServiceBase data)
        {
            throw new NotImplementedException();
        }
    }



    public class TemplateServicesShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected readonly SubscriptionClientService subscriptionClientService;
        protected IBuilderServicesApi<E> builderApi;
        protected IBuilderRequestApi<E> builderRequestApi;
        private readonly IBuilderServicesComponent<E> builderComponents;
        public IBuilderServicesComponent<E> BuilderComponents { get => builderComponents; }
        public TemplateServicesShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                IBuilderServicesComponent<E> builderComponents,
                NavigationManager navigation,
                IDialogService dialogService,
                ISnackbar snackbar,
                SubscriptionClientService subscriptionClientService
            ) : base(mapper, AuthService, client)
        {



            builderComponents = new BuilderServicesComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;
            this.subscriptionClientService = subscriptionClientService;
        }

    }

    public class TemplateServices : TemplateServicesShare<LAHJAClientService, DataBuildServiceBase>
    {
        
        private List<string> _errors = new List<string>();
         //protected readonly SubscriptionClientService subscriptionClientService;
        public List<string> Errors => _errors;

        public TemplateServices(
            IMapper mapper,
            AuthService authService,
            LAHJAClientService client,
            IBuilderServicesComponent<DataBuildServiceBase> builderComponents,
            SubscriptionClientService subscriptionClientService,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar
        ) : base(mapper, authService, client, builderComponents, navigation, dialogService, snackbar, subscriptionClientService)
        {
            this.BuilderComponents.SubmitCreate = OnCreate;
            this.BuilderComponents.SubmitUpdate = OnUpdate;
            this.BuilderComponents.SubmitDelete = OnDelete;
            this.BuilderComponents.SubmitGetOne = GetOne;
            this.BuilderComponents.SubmitGetAll = GetAll;
            this.BuilderComponents.SubmitText2Text = OnSubmitText2Text;
            this.BuilderComponents.SubmitText2Speech = OnSubmitText2Speech;
            this.BuilderComponents.SubmitVoiceBot = OnSubmitVoiceBot;

            this.builderApi = new BuilderServiceApiClient(mapper, client);
            this.builderRequestApi = new BuilderServiceApiClient(mapper, client);
        }

        private async Task OnSubmitText2Speech(DataBuildServiceBase data) {
        
        
        }
        private async Task OnSubmitText2Text(DataBuildServiceBase data) {

            var response = await builderRequestApi.CreateRequestAsync(data);
            if (response.Succeeded)
            {
                var map = mapper.Map<DataBuildServiceBase>(response.Data);
                map.Text = data.Text;
                var resService = await builderApi.Text2Text(map);
                if (resService.Succeeded)
                {
                    builderRequestApi.CreateEventAsync(data);
                }
                else
                {

                }
            }
            else
            {
                Snackbar.Add("لايوجد لديك رصيد كافي من الطلبات", Severity.Warning);
            }

        }
        private async Task OnSubmitVoiceBot(DataBuildServiceBase data)
        {
            //var response=await builderRequestApi.AllowedAsync(data);
            var response=await builderRequestApi.CreateRequestAsync(data);
            if (response.Succeeded)
            {
                var map = mapper.Map<DataBuildServiceBase>(response.Data);
                map.Text=data.Text;
                var resService = await builderApi.Text2Text(map);
                if (resService.Succeeded)
                {
                    var resSpeech = await builderApi.Text2Speech(map);
                    if (resSpeech.Succeeded)
                    {
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            else
            {
                Snackbar.Add("لايوجد لديك رصيد كافي من الطلبات",Severity.Warning);
            }
        }
        private async Task OnCreate(DataBuildServiceBase data)
        {
            var response = await builderApi.CreateAsync(data);
            if (!response.Succeeded)
                _errors = response.Messages;
        }

        private async Task OnUpdate(DataBuildServiceBase data)
        {
            var response = await builderApi.UpdateAsync(data);
            if (!response.Succeeded)
                _errors = response.Messages;
        }

        private async Task<Result<List<ServiceResponse>>> GetAll(DataBuildServiceBase? data=null)
        {
            return await builderApi.GetAllAsync();
            
        }

        private async Task OnDelete(DataBuildServiceBase data)
        {
            var response = await builderApi.DeleteAsync(data);
            if (!response.Succeeded)
                _errors = response.Messages;
        }

        private async Task<Result<ServiceResponse>> GetOne(DataBuildServiceBase data)
        {
            return await builderApi.GetOneAsync(data);
        }
    }


   
}





