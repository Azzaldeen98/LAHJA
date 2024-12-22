using AutoMapper;
using Domain.Entities.Subscriptions.Response;
using Domain.Wrapper;
using LAHJA.ApplicationLayer.Subscription;
using LAHJA.ApplicationLayer.Subscription;
using LAHJA.Data.UI.Templates.Base;
using LAHJA.Data.UI.Templates.Subscription;
using LAHJA.Helpers.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;


namespace LAHJA.Data.UI.Templates.Subscription
{

    public class DataBuildSubscriptionBase
    {
        public string Id { get; set; }
    }




    public interface IBuilderSubscriptionComponent<T> : IBuilderComponents<T>
    {
        public Func<T, Task> SubmitSearch { get; set; }
        public Func<Task> SubmitGetAll { get; set; }
        public Func<T, Task> SubmitPause { get; set; }
        public Func<T, Task> SubmitResume { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }


    }

    public interface IBuilderSubscriptionApi<T> : IBuilderApi<T>
    {


        //Task<Result<List<SubscriptionResponse>>> SearchAsync(T data);
        Task<Result<List<SubscriptionResponse>>> GetAllAsync();
        //Task<Result<SubscriptionResponse>> CreateAsync(T data);
        Task<Result<SubscriptionResponse>> ResumeAsync(T data);
        Task<Result<SubscriptionResponse>> PauseAsync(T data);
        Task<Result<SubscriptionResponse>> DeleteAsync(T data);
        //Task<Result<SubscriptionResponse>> UpdateAsync(T data);


    }

    public abstract class BuilderSubscriptionApi<T, E> : BuilderApi<T, E>, IBuilderSubscriptionApi<E>
    {

        public  BuilderSubscriptionApi(IMapper mapper, T service) : base(mapper, service)
        {

        }

        //public abstract Task<Result<SubscriptionResponse>> CreateAsync(E data);

        public abstract Task<Result<SubscriptionResponse>> DeleteAsync(E dataId);

        public abstract Task<Result<List<SubscriptionResponse>>> GetAllAsync();

        public abstract Task<Result<SubscriptionResponse>> PauseAsync(E data);
        public abstract Task<Result<SubscriptionResponse>> ResumeAsync(E data);

        //public abstract Task<Result<SubscriptionResponse>> UpdateAsync(E data);

       
    }
    public class BuilderSubscriptionComponent<T> : IBuilderSubscriptionComponent<T>
    {


        public Func<T, Task> SubmitSearch { get; set; }
        public Func <Task> SubmitGetAll { get; set; }
        public Func<T, Task> SubmitPause { get; set; }
        public Func<T, Task> SubmitResume { get; set; }
        public Func<T, Task> SubmitDelete { get; set; }
        public Func<T, Task> SubmitUpdate { get; set; }


    }


    public class TemplateSubscriptionShare<T, E> : TemplateBase<T, E>
    {
        protected readonly NavigationManager navigation;
        protected readonly IDialogService dialogService;
        protected readonly ISnackbar Snackbar;
        protected IBuilderSubscriptionApi<E> builderApi;
        private readonly IBuilderSubscriptionComponent<E> builderComponents;
        public IBuilderSubscriptionComponent<E> BuilderComponents { get => builderComponents; }
        public TemplateSubscriptionShare(

               IMapper mapper,
               AuthService AuthService,
                T client,
                IBuilderSubscriptionComponent<E> builderComponents,
                NavigationManager navigation,
                IDialogService dialogService,
                ISnackbar snackbar


            ) : base(mapper, AuthService, client)
        {



            builderComponents = new BuilderSubscriptionComponent<E>();
            this.navigation = navigation;
            this.dialogService = dialogService;
            this.Snackbar = snackbar;
            //this.builderApi = builderApi;
            this.builderComponents = builderComponents;


        }

    }


    public class BuilderSubscriptionApiClient : BuilderSubscriptionApi<SubscriptionClientService, DataBuildSubscriptionBase>, IBuilderSubscriptionApi<DataBuildSubscriptionBase>
    {
        public BuilderSubscriptionApiClient(IMapper mapper, SubscriptionClientService service) : base(mapper, service)
        {

        }

        public override async Task<Result<SubscriptionResponse>> PauseAsync(DataBuildSubscriptionBase data)
        {
            //var model = Mapper.Map<SubscriptionCreate>(data);
            var res = await Service.PauseAsync(data.Id);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<SubscriptionResponse>(res.Data);
                    return Result<SubscriptionResponse>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<SubscriptionResponse>.Fail();
                }
            }
            else
            {
                return Result<SubscriptionResponse>.Fail(res.Messages);
            }
        }

        public override async Task<Result<SubscriptionResponse>> DeleteAsync(DataBuildSubscriptionBase data)
        {

            var res = await Service.DeleteAsync(data.Id);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<SubscriptionResponse>(res.Data);
                    return Result<SubscriptionResponse>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<SubscriptionResponse>.Fail();
                }
            }
            else
            {
                return Result<SubscriptionResponse>.Fail(res.Messages);
            }
        }

        public override async Task<Result<List<SubscriptionResponse>>> GetAllAsync()
        {
            //var model = Mapper.Map<FilterResponseData>(filter);
            var res = await Service.GetAllAsync();
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<List<SubscriptionResponse>>(res.Data);
                    return Result<List<SubscriptionResponse>>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<List<SubscriptionResponse>>.Fail();
                }
            }
            else
            {
                return Result<List<SubscriptionResponse>>.Fail(res.Messages);
            }

        }

        public override async Task<Result<SubscriptionResponse>> ResumeAsync(DataBuildSubscriptionBase data)
        {
            //var model = Mapper.Map<SubscriptionSearchRequest>(data);
            var res = await Service.ResumeAsync(data.Id);
            if (res.Succeeded)
            {
                try
                {
                    var map = Mapper.Map<SubscriptionResponse>(res.Data);
                    return Result<SubscriptionResponse>.Success(map);

                }
                catch (Exception e)
                {
                    return Result<SubscriptionResponse>.Fail();
                }
            }
            else
            {
                return Result<SubscriptionResponse>.Fail(res.Messages);
            }
        }


        //public override async Task<Result<SubscriptionResponse>> UpdateAsync(DataBuildSubscriptionBase data)
        //{
        //    //var model = Mapper.Map<SubscriptionUpdate>(data);
        //    var res = await Service.UpdateAsync(model);
        //    if (res.Succeeded)
        //    {
        //        try
        //        {
        //            var map = Mapper.Map<SubscriptionResponse>(res.Data);
        //            return Result<SubscriptionResponse>.Success(map);

        //        }
        //        catch (Exception e)
        //        {
        //            return Result<SubscriptionResponse>.Fail();
        //        }
        //    }
        //    else
        //    {
        //        return Result<SubscriptionResponse>.Fail(res.Messages);
        //    }
        //}
    }


    public class TemplateSubscription : TemplateSubscriptionShare<SubscriptionClientService, DataBuildSubscriptionBase>
    {
   
        public List<SubscriptionResponse> Subscriptions { get => _Subscriptions; }
     
        public List<string> Errors { get => _errors; }


        private List<SubscriptionResponse> _Subscriptions = new List<SubscriptionResponse>();


        public TemplateSubscription(
            IMapper mapper,
            AuthService AuthService,
            SubscriptionClientService client,
            IBuilderSubscriptionComponent<DataBuildSubscriptionBase> builderComponents,
            NavigationManager navigation,
            IDialogService dialogService,
            ISnackbar snackbar) : base(mapper, AuthService, client, builderComponents, navigation, dialogService, snackbar)
        {
            //this.BuilderComponents.SubmitCreate = OnSubmitCreateSubscription;
            this.BuilderComponents.SubmitPause = OnSubmitPauseSubscription;
            this.BuilderComponents.SubmitGetAll = OnSubmitGetAllSubscriptions;
            this.BuilderComponents.SubmitDelete = OnSubmitDeleteSubscription;
            this.BuilderComponents.SubmitResume= OnSubmitUResumeSubscription;


            this.builderApi = new BuilderSubscriptionApiClient(mapper, client);

          

        }



     
        private async Task OnSubmitDeleteSubscription(DataBuildSubscriptionBase dataBuildSubscriptionBase)
        {

            if (dataBuildSubscriptionBase != null)
            {
                var response = await builderApi.DeleteAsync(dataBuildSubscriptionBase);
                if (response.Succeeded)
                {

                }
                else
                {
                    _errors = response.Messages;
                }
            }

        }
        private async Task OnSubmitPauseSubscription(DataBuildSubscriptionBase dataBuildSubscriptionBase)
        {

            if (dataBuildSubscriptionBase != null)
            {
                var response = await builderApi.PauseAsync(dataBuildSubscriptionBase);
                if (response.Succeeded)
                {

                }
                else
                {
                    _errors = response.Messages;
                }
            }

        }

        private async Task OnSubmitUResumeSubscription(DataBuildSubscriptionBase dataBuildSubscriptionBase)
        {

            if (dataBuildSubscriptionBase != null)
            {
                var response = await builderApi.ResumeAsync(dataBuildSubscriptionBase);
                if (response.Succeeded)
                {

                }
                else
                {
                    _errors = response.Messages;
                }
            }

        }
        private async Task OnSubmitGetAllSubscriptions()
        {

        
            
                var response = await builderApi.GetAllAsync();
                if (response.Succeeded)
                {
                    _Subscriptions = response.Data;
                }
                else
                {
                _errors = response.Messages;
            }
        }

   
    }
}





