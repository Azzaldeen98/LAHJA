
using AutoMapper;
using Domain.Entities.Request.Request;
using Domain.Entities.Request.Response;
using Domain.Repository.Request;
using Domain.ShareData;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.Payment;
using Infrastructure.DataSource.Seeds;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models.Request.Response;
using Infrastructure.Models.Subscriptions.Response;
using Shared.Settings;


namespace Infrastructure.Repository.Subscription
{

    public class RequestRepository : IRequestRepository
    {
        private readonly SeedsSubscriptionsPlans seedsPlans;
        private readonly SeedsSubscriptionsData seedsSubscriptionsData;
        private readonly SubscriptionsApiClient subscriptionApiClient;
        private readonly IMapper _mapper;
        private readonly ISessionUserManager _sessionUserManager;
        private readonly ApplicationModeService appModeService;
        public RequestRepository(
            IMapper mapper,
            SeedsSubscriptionsPlans seedsPlans,
            ApplicationModeService appModeService,
            SubscriptionsApiClient subscriptionApiClient,
            SeedsSubscriptionsData seedsSubscriptionsData,
            ISessionUserManager sessionUserManager)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;

            this.subscriptionApiClient = subscriptionApiClient;
            this.seedsSubscriptionsData = seedsSubscriptionsData;
            _sessionUserManager = sessionUserManager;
        }

        public async Task<Result<bool>> HasActiveSubscriptionAsync()
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<List<SubscriptionResponseModel>>>(
                 async () => await subscriptionApiClient.getAllAsync(),
                  async () =>
                  {
                      var email = await _sessionUserManager.GetEmailAsync();
                      if (email == null)
                          return Result<List<SubscriptionResponseModel>>.Fail();

                      var data = seedsSubscriptionsData.getActiveSubscriptions(email);
                      if (data != null)
                      {
                          var items = _mapper.Map<List<SubscriptionResponseModel>>(data);
                          return Result<List<SubscriptionResponseModel>>.Success(items);
                      }


                      return Result<List<SubscriptionResponseModel>>.Fail();
                  });

            if (response.Succeeded)
            {
                return Result<bool>.Success(true);
            }
            else
            {
                return Result<bool>.Fail();
            }


        }


        public async Task<Result<RequestResponse>> CreateAsync(RequestCreate request)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result>(
                  async () => Result<bool>.Success(),
                  async () =>
                  {

                      return Result<bool>.Fail();
                      //          var email = await _sessionUserManager.GetEmailAsync();
                      //          if(email == null)
                      //              return Result<SubscriptionResponseModel>.Fail();

                      //          var plan= seedsPlans.getOne(request.PlanId);
                      //          if (plan == null)
                      //              return Result<SubscriptionResponseModel>.Fail();

                      //          var model=_mapper.Map<SubscriptionModel>(request);
                      //          model.UserId = email;
                      //          model.PlanId = plan.Id;
                      //          model.SubscriptionPlan = plan;
                      //          model.SubscriptionPlan.Active = true; 
                      //          model.StartDate = DateTime.Now;
                      //          model.CancelAtPeriodEnd = true;

                      //          seedsSubscriptionsData.AddSubscription(model);
                      //          var res = seedsSubscriptionsData.SearchSubscriptions(x => x.UserId == email).FirstOrDefault();
                      //          if (res != null)
                      //          {
                      //              var data = _mapper.Map<SubscriptionResponseModel>(res);
                      //              return Result<SubscriptionResponseModel>.Success(data);
                      //          }
                      //          return Result<SubscriptionResponseModel>.Fail();
                  });

            if (response.Succeeded)
            {
                //var result = (response.Data != null) ? _mapper.Map<SubscriptionResponse>(response.Data) : null;
                return Result<RequestResponse>.Success();
            }
            else
            {
                return Result<RequestResponse>.Fail(response.Messages);
            }
        }

        public async Task<Result<RequestAllowed>> AllowedService(RequestCreate request)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<RequestAllowedModel>>(
                  async () => Result<RequestAllowedModel>.Success(),
                  async () =>
                  {
                      return Result<RequestAllowedModel>.Success();
                  });

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<RequestAllowed>(response.Data) : null;
                return Result<RequestAllowed>.Success(result);
            }
            else
            {
                return Result<RequestAllowed>.Fail(response.Messages);
            }
        }

        public Task<Result<RequestResponse>> CreateRequestAsync(RequestCreate request)
        {
            throw new NotImplementedException();
        }

        public Task<Result<RequestResponse>> RequestAllowedAsync(string serviceId)
        {
            throw new NotImplementedException();
        }
    }
}
