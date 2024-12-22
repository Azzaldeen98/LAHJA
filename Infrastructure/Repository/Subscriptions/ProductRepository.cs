
using AutoMapper;
using Domain.Wrapper;
using Infrastructure.DataSource.Seeds;

using Shared.Settings;
using Infrastructure.DataSource.ApiClient.Payment;

using Domain.ShareData.Base;
using Domain.Repository.Subscriptions;
using Infrastructure.Models.Plans;
using Domain.Entities.Subscriptions.Response;
using Infrastructure.Models.Subscriptions.Request;


namespace Infrastructure.Repository.Subscription
{
    
    public class SubscriptionsRepository : ISubscriptionsRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly SubscriptionsApiClient subscriptionApiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public SubscriptionsRepository(
            IMapper mapper,
            SeedsPlans seedsPlans,
            ApplicationModeService appModeService,
            SubscriptionsApiClient subscriptionApiClient)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;

            this.subscriptionApiClient = subscriptionApiClient;
        }


        public async Task<Result<List<SubscriptionResponse>>> getAllAsync()
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<List<SubscriptionResponseModel>>>(
                 async () => await subscriptionApiClient.getAllAsync(),
                  async () => Result<List<SubscriptionResponseModel>>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<List<SubscriptionResponse>>(response.Data) : null;
                return Result<List<SubscriptionResponse>>.Success(result);
            }
            else
            {
                return Result<List<SubscriptionResponse>>.Fail(response.Messages);
            }


        }

        public async Task<Result<SubscriptionResponse>> PauseAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<SubscriptionResponseModel>>(
                 async () => await subscriptionApiClient.PauseAsync(id),
                  async () => Result<SubscriptionResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<SubscriptionResponse>(response.Data) : null;
                return Result<SubscriptionResponse>.Success(result);
            }
            else
            {
                return Result<SubscriptionResponse>.Fail(response.Messages);
            }



        }

        public async Task<Result<SubscriptionResponse>> ResumeAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<SubscriptionResponseModel>>(
                 async () => await subscriptionApiClient.ResumeAsync(id),
                  async () => Result<SubscriptionResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<SubscriptionResponse>(response.Data) : null;
                return Result<SubscriptionResponse>.Success(result);
            }
            else
            {
                return Result<SubscriptionResponse>.Fail(response.Messages);
            }

        }

        public async Task<Result<SubscriptionResponse>> DeleteAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<SubscriptionResponseModel>>(
                 async () => await subscriptionApiClient.DeleteAsync(id),
                  async () => Result<SubscriptionResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<SubscriptionResponse>(response.Data) : null;
                return Result<SubscriptionResponse>.Success(result);
            }
            else
            {
                return Result<SubscriptionResponse>.Fail(response.Messages);
            }
        }


   

      
    } 
}
