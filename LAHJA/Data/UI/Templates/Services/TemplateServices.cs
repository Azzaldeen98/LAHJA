using AutoMapper;
using Domain.Entities.Event.Request;
using Domain.Entities.Event.Response;
using Domain.Entities.Request.Request;
using Domain.Entities.Request.Response;
using Domain.Entities.Service.Request;
using Domain.Entities.Service.Response;
using Domain.ShareData.Base;
using Domain.ShareData.Base.Request;
using Domain.Wrapper;
using LAHJA.ApiClient.Models;
using LAHJA.ApplicationLayer.Request;
using LAHJA.ApplicationLayer.Service;
using LAHJA.ApplicationLayer.Subscription;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Interfaces;


namespace LAHJA.Data.UI.Templates.Services
{

    public class DataBuildServiceBase
    {
 
        public string? PublicKey { get; set; }
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
        Task<Result<ServiceResponse>> ResultRequestAsync(T data);

    }

    public abstract class BuilderServicesApi<T, E> : BuilderApi<T, E>, IBuilderServicesApi<E>, IBuilderRequestApi<E>
    {

        protected readonly RequestClientService requestClientService;
        public BuilderServicesApi(IMapper mapper, T service, RequestClientService requestClientService) : base(mapper, service)
        {
            this.requestClientService = requestClientService;
        }

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

        public abstract Task<Result<EventResponse>> CreateEventAsync(E data);

        public abstract Task<Result<ServiceResponse>> ResultRequestAsync(E data);
        public abstract Task<Result<DeleteResponse>> DeleteRequestAsync(E data);
       
    }

    public class BuilderServiceApiClient : BuilderServicesApi<LAHJAClientService, DataBuildServiceBase>, IBuilderServicesApi<DataBuildServiceBase>,IBuilderRequestApi<DataBuildServiceBase>
    {
        
        public BuilderServiceApiClient(IMapper mapper, LAHJAClientService service, RequestClientService requestClientService) : base(mapper, service,requestClientService) { }

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
            var mapReq = Mapper.Map<RequestCreate>(data);
            var res = await requestClientService.CreateRequestAsync(mapReq);
            if(res.Succeeded)
            {
                var req = new Data.UI.Models.QueryRequestTextToText { Text = data.Text };
                //req.URL += data.ModelAi;
                var map = Mapper.Map<Data.UI.Models.QueryRequestTextToText>(req);
                var servRes= await Service.Text2TextAsync(req);
                if (servRes.Succeeded)
                {
                    var _event = Mapper.Map<EventRequest>(res.Data);
                    _event.RequestId = res.Data.Id;
                    await requestClientService.CreateEventAsync(_event);
                }
                else
                {
                    var _event = Mapper.Map<EventRequest>(res);
                    _event.RequestId = res.Data.Id;
            
                    await requestClientService.CreateEventAsync(_event);
                    return  Result<ServiceAIResponse>.Fail();
                }
            }
            else
            {
                return Result<ServiceAIResponse>.Fail("لايوجد لديك رصيد كافي من الطلبات");
   
            }

            return Result<ServiceAIResponse>.Fail("Finished Request!!");

        }

        public override async Task<Result<ServiceAIResponse>> Text2Speech(DataBuildServiceBase data)
        {
            var map = Mapper.Map<Models.QueryRequestTextToSpeech>(data);
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

        public override async Task<Result<RequestResponse>> CreateRequestAsync(DataBuildServiceBase data)
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

        public override async Task<Result<ServiceResponse>> ResultRequestAsync(DataBuildServiceBase data)
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
        protected readonly RequestClientService requestClientService;
        public IBuilderServicesComponent<E> BuilderComponents { get => builderComponents; }
        public TemplateServicesShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                RequestClientService requestClientService,
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
        
        //private List<string> _errors = new List<string>();
        public  bool IsEndProcessing { get => _isResponse; }
        public  string Response { get => _response; }
 
        private string _response = "";
        private bool _isResponse = false;
        public List<string> Errors => _errors;

        public TemplateServices(
            IMapper mapper,
            AuthService authService,
            LAHJAClientService client,
             RequestClientService requestClientService,
            IBuilderServicesComponent<DataBuildServiceBase> builderComponents,
            SubscriptionClientService subscriptionClientService,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar
        ) : base(mapper, authService, client, requestClientService, builderComponents, navigation, dialogService, snackbar, subscriptionClientService)
        {
            this.BuilderComponents.SubmitCreate = OnCreate;
            this.BuilderComponents.SubmitUpdate = OnUpdate;
            this.BuilderComponents.SubmitDelete = OnDelete;
            this.BuilderComponents.SubmitGetOne = GetOne;
            this.BuilderComponents.SubmitGetAll = GetAll;
            this.BuilderComponents.SubmitText2Text = OnSubmitText2Text;
            this.BuilderComponents.SubmitText2Speech = OnSubmitText2Speech;
            this.BuilderComponents.SubmitVoiceBot = OnSubmitVoiceBot;

            this.builderApi = new BuilderServiceApiClient(mapper, client, requestClientService);
            this.builderRequestApi = new BuilderServiceApiClient(mapper, client, requestClientService);
        }

        private async Task OnSubmitText2Speech(DataBuildServiceBase data) {
        
        
        }
        private async Task OnSubmitText2Text(DataBuildServiceBase data) {

            //var response = await builderRequestApi.CreateRequestAsync(data);
            //if (response.Succeeded)
            //{
            //    var map = mapper.Map<DataBuildServiceBase>(response.Data);
            //    map.Text = data.Text;
                var resService = await builderApi.Text2Text(data);
                if (resService.Succeeded)
                {
                     _response = resService.Data.Result;
                    Snackbar.Add("Success", Severity.Success);
                      // await builderRequestApi.CreateEventAsync(new DataBuildServiceBase { PublicKey= "pifgigdfgidf", Token=""});
                 }
                else
                {
                     Snackbar.Add(resService.Messages?[0]??"null", Severity.Warning);
                }   
            _isResponse = true;
       
            //}
            //else
            //{
            //    Snackbar.Add("لايوجد لديك رصيد كافي من الطلبات", Severity.Warning);
            //}

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





