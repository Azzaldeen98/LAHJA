//using AutoMapper;
//using Domain.Entities.Profile;
//using Domain.Entities.Profile.Request;
//using Domain.ShareData.Base;
//using Domain.Wrapper;
//using Infrastructure.DataSource.ApiClient.Plans;
//using LAHJA.ApplicationLayer.Profile;
//using LAHJA.Data.UI.Templates.Base;
//using LAHJA.Data.UI.Templates.Profile;
//using LAHJA.Helpers.Services;
//using Microsoft.AspNetCore.Components;
//using MudBlazor;

//namespace LAHJA.Data.UI.Templates.Profile
//{
//    public class DataBuildProfileBase
//    {
//        public string Id { get; set; }
//    }
//    public interface IBuilderProfileComponent<T> : IBuilderComponents<T>
//    {




//        public Func<T, Task> SubmitSearch { get; set; }
//        public Func<T, Task> SubmitCreate { get; set; }
//        public Func<T, Task> SubmitDelete { get; set; }
//        public Func<T, Task> SubmitUpdate { get; set; }


//    }

//    public interface IBuilderProfileApi<T> : IBuilderApi<T>
//    {


//        Task<Result<List<ProfileResponse>>> SearchAsync(T data);

//        Task<Result<ProfileResponse>> CreateAsync(T data);
//        Task<Result<DeleteResponse>> DeleteAsync(T data);
//        Task<Result<ProfileResponse>> UpdateAsync(T data);


//    }

//    public abstract class BuilderProfileApi<T, E> : BuilderApi<T, E>, IBuilderProfileApi<E>
//    {

//        public BuilderProfileApi(IMapper mapper, T service) : base(mapper, service)
//        {

//        }

//        public abstract Task<Result<ProfileResponse>> CreateAsync(E data);


//        public abstract Task<Result<DeleteResponse>> DeleteAsync(E dataId);



//        public abstract Task<Result<List<ProfileResponse>>> SearchAsync(E data);


//        public abstract Task<Result<ProfileResponse>> UpdateAsync(E data);



//    }
//    public class BuilderProfileComponent<T> : IBuilderProfileComponent<T>
//    {


//        public Func<T, Task> SubmitSearch { get; set; }
//        public Func<T, Task> SubmitCreate { get; set; }
//        public Func<T, Task> SubmitDelete { get; set; }
//        public Func<T, Task> SubmitUpdate { get; set; }


//    }


//    public class TemplateProfileShare<T, E> : TemplateBase<T, E>
//    {
//        protected readonly NavigationManager navigation;
//        protected readonly IDialogService dialogService;
//        protected readonly ISnackbar Snackbar;
//        protected IBuilderProfileApi<E> builderApi;
//        private readonly IBuilderProfileComponent<E> builderComponents;
//        public IBuilderProfileComponent<E> BuilderComponents { get => builderComponents; }
//        public TemplateProfileShare(

//               IMapper mapper,
//               AuthService AuthService,
//                T client,
//                IBuilderProfileComponent<E> builderComponents,
//                NavigationManager navigation,
//                IDialogService dialogService,
//                ISnackbar snackbar


//            ) : base(mapper, AuthService, client)
//        {



//            builderComponents = new BuilderProfileComponent<E>();
//            this.navigation = navigation;
//            this.dialogService = dialogService;
//            this.Snackbar = snackbar;
//            //this.builderApi = builderApi;
//            this.builderComponents = builderComponents;


//        }

//    }


//    public class BuilderProfileApiClient : BuilderProfileApi<ProfileClientService, DataBuildProfileBase>, IBuilderProfileApi<DataBuildProfileBase>
//    {
//        public BuilderProfileApiClient(IMapper mapper, ProfileClientService service) : base(mapper, service)
//        {

//        }

//        public override async Task<Result<ProfileResponse>> CreateAsync(DataBuildProfileBase data)
//        {
//            var model = Mapper.Map<ProfileCreate>(data);
//            var res = await Service.CreateAsync(model);
//            if (res.Succeeded)
//            {
//                try
//                {
//                    var map = Mapper.Map<ProfileResponse>(res.Data);
//                    return Result<ProfileResponse>.Success(map);

//                }
//                catch (Exception e)
//                {
//                    return Result<ProfileResponse>.Fail();
//                }
//            }
//            else
//            {
//                return Result<ProfileResponse>.Fail(res.Messages);
//            }
//        }

//        public override async Task<Result<DeleteResponse>> DeleteAsync(DataBuildProfileBase data)
//        {

//            var res = await Service.DeleteAsync(data.Id);
//            if (res.Succeeded)
//            {
//                try
//                {
//                    var map = Mapper.Map<DeleteResponse>(res.Data);
//                    return Result<DeleteResponse>.Success(map);

//                }
//                catch (Exception e)
//                {
//                    return Result<DeleteResponse>.Fail();
//                }
//            }
//            else
//            {
//                return Result<DeleteResponse>.Fail(res.Messages);
//            }
//        }



//        public override async Task<Result<List<ProfileResponse>>> SearchAsync(DataBuildProfileBase data)
//        {
//            var model = Mapper.Map<ProfileSearchOptionsRequest>(data);
//            var res = await Service.SearchAsync(model);
//            if (res.Succeeded)
//            {
//                try
//                {
//                    var map = Mapper.Map<List<ProfileResponse>>(res.Data);
//                    return Result<List<ProfileResponse>>.Success(map);

//                }
//                catch (Exception e)
//                {
//                    return Result<List<ProfileResponse>>.Fail();
//                }
//            }
//            else
//            {
//                return Result<List<ProfileResponse>>.Fail(res.Messages);
//            }
//        }

//        public override async Task<Result<ProfileResponse>> UpdateAsync(DataBuildProfileBase data)
//        {
//            var model = Mapper.Map<ProfileUpdate>(data);
//            var res = await Service.UpdateAsync(model);
//            if (res.Succeeded)
//            {
//                try
//                {
//                    var map = Mapper.Map<ProfileResponse>(res.Data);
//                    return Result<ProfileResponse>.Success(map);

//                }
//                catch (Exception e)
//                {
//                    return Result<ProfileResponse>.Fail();
//                }
//            }
//            else
//            {
//                return Result<ProfileResponse>.Fail(res.Messages);
//            }
//        }
//    }

//}
