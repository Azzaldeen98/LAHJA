using AutoMapper;
using Domain.Entities.Service.Request;
using Domain.Entities.Service.Response;
using Domain.ShareData.Base;
using Domain.Wrapper;
using LAHJA.ApplicationLayer.Service;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;


namespace LAHJA.Data.UI.Templates.Services
{

    public class DataBuildServiceBase
    {
         public string Id {  get; set; }


    }



    public interface IBuilderServicesComponent<T> : IBuilderComponents<T>
    {
        Func<T, Task> SubmitGetOne { get; set; }
        Func<T, Task> SubmitGetAll { get; set; }
        Func<T, Task> SubmitCreate { get; set; }
        Func<T, Task> SubmitDelete { get; set; }
        Func<T, Task> SubmitUpdate { get; set; }
    }

    public class BuilderServicesComponent<T> : IBuilderServicesComponent<T>
    {


        public Func<T, Task> SubmitGetOne { get; set; }
        public Func<T, Task> SubmitGetAll { get; set; }
        public Func<T, Task> SubmitCreate { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }


    }
    public interface IBuilderServicesApi<T> : IBuilderApi<T>
    {
        Task<Result<ServiceResponse>> GetOneAsync(T id);
        Task<Result<List<ServiceResponse>>> GetAllAsync();
        Task<Result<ServiceResponse>> CreateAsync(T data);
        Task<Result<DeleteResponse>> DeleteAsync(T data);
        Task<Result<ServiceResponse>> UpdateAsync(T data);
    }



    public abstract class BuilderServicesApi<T, E> : BuilderApi<T, E>, IBuilderServicesApi<E>
    {
        public BuilderServicesApi(IMapper mapper, T service) : base(mapper, service) { }

        public abstract Task<Result<ServiceResponse>> CreateAsync(E data);
        public abstract Task<Result<DeleteResponse>> DeleteAsync(E dataId);
        public abstract Task<Result<List<ServiceResponse>>> GetAllAsync();
        public abstract Task<Result<ServiceResponse>> GetOneAsync(E id);
        public abstract Task<Result<ServiceResponse>> UpdateAsync(E data);
    }

    public class BuilderServiceApiClient : BuilderServicesApi<LAHJAClientService, DataBuildServiceBase>, IBuilderServicesApi<DataBuildServiceBase>
    {
        public BuilderServiceApiClient(IMapper mapper, LAHJAClientService service) : base(mapper, service) { }

        public override async Task<Result<ServiceResponse>> CreateAsync(DataBuildServiceBase data)
        {
            var model = Mapper.Map<ServiceRequest>(data);
            return await Service.CreateAsync(model);
        }

        public override async Task<Result<DeleteResponse>> DeleteAsync(DataBuildServiceBase data)
        {
            return await Service.DeleteAsync(data.Id);
        }

        public override async Task<Result<List<ServiceResponse>>> GetAllAsync()
        {
            return await Service.GetAllAsync();
        }

 

        public override async Task<Result<ServiceResponse>> UpdateAsync(DataBuildServiceBase data)
        {
            var model = Mapper.Map<ServiceRequest>(data);
            return await Service.UpdateAsync(model);
        }    
        public override async Task<Result<ServiceResponse>> GetOneAsync(DataBuildServiceBase data)
        {
          
            return await Service.GetOneAsync(data.Id);
        }
    }



    public class TemplateServicesShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderServicesApi<E> builderApi;
        private readonly IBuilderServicesComponent<E> builderComponents;
        public IBuilderServicesComponent<E> BuilderComponents { get => builderComponents; }
        public TemplateServicesShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                IBuilderServicesComponent<E> builderComponents,
                NavigationManager navigation,
                IDialogService dialogService,
                ISnackbar snackbar


            ) : base(mapper, AuthService, client)
        {



            builderComponents = new BuilderServicesComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;


        }

    }

    public class TemplateServices : TemplateServicesShare<LAHJAClientService, DataBuildServiceBase>
    {
        
        private List<string> _errors = new List<string>();
 
        public List<string> Errors => _errors;

        public TemplateServices(
            IMapper mapper,
            AuthService authService,
            LAHJAClientService client,
            IBuilderServicesComponent<DataBuildServiceBase> builderComponents,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar
        ) : base(mapper, authService, client, builderComponents, navigation, dialogService, snackbar)
        {
            this.BuilderComponents.SubmitCreate = OnCreate;
            this.BuilderComponents.SubmitUpdate = OnUpdate;
            this.BuilderComponents.SubmitDelete = OnDelete;
            this.BuilderComponents.SubmitGetOne = GetOne;
            this.BuilderComponents.SubmitGetAll = GetAll;

            this.builderApi = new BuilderServiceApiClient(mapper, client);
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





