﻿using AutoMapper;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.Subscriptions.Request;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataSource.ApiClient.Payment
{
    public class SubscriptionsApiClient : BuildApiClient<SubscriptionsClient>
    {

        public SubscriptionsApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config) : base(clientFactory, mapper, config)
        {
        }

    
   
        public async Task<Result<List<SubscriptionResponseModel>>> getAllAsync()
        {
            try
            {
                //var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient();
                var response = await client.GetSubscriptionsAsync();


                var resModel = _mapper.Map<List<SubscriptionResponseModel>>(response);
                return Result<List<SubscriptionResponseModel>>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<List<SubscriptionResponseModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }  
        
        public async Task<Result<SubscriptionResponseModel>> PauseAsync(string id)
        {
            try
            {
                //var model = _mapper.Map<ProductUpdate>(request);
                var client = await GetApiClient();
                var response = await client.PauseAsync(id);


                var resModel = _mapper.Map<SubscriptionResponseModel>(response);
                return Result<SubscriptionResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<SubscriptionResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

        public async Task<Result<SubscriptionResponseModel>> ResumeAsync(string id)
        {
            try
            {
                //var model = _mapper.Map<ProductCreate>(request);
                var client = await GetApiClient();
                var response = await client.ResumeAsync(id);


                var resModel = _mapper.Map<SubscriptionResponseModel>(response);
                return Result<SubscriptionResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<SubscriptionResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

        public async Task<Result<SubscriptionResponseModel>> DeleteAsync(string id)
        {
            try
            {
              
                var client = await GetApiClient();
                var response = await client.CancelSubscriptionAsync(id);


                var resModel = _mapper.Map<SubscriptionResponseModel>(response);
                return Result<SubscriptionResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<SubscriptionResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

    }
}