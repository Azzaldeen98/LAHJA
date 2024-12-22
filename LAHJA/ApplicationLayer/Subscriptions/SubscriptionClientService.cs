﻿using AutoMapper;
using Domain.Entities.Subscriptions;
using Domain.Entities.Subscriptions.Response;
using Domain.Wrapper;
using LAHJA.Helpers.Services;

namespace LAHJA.ApplicationLayer.Subscription
{
    public class SubscriptionClientService
    {
        private readonly Application.Services.Subscriptions.SubscriptionService _subscriptionService;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public SubscriptionClientService(Application.Services.Subscriptions.SubscriptionService subscriptionService, IMapper mapper, TokenService tokenService)
        {
            this._subscriptionService = subscriptionService;
            this._mapper = mapper;
            this._tokenService = tokenService;
        }

        public async Task<Result<SubscriptionResponse>> PauseAsync(string id)
        {
            return await _subscriptionService.PauseAsync(id);
        }

        public async Task<Result<SubscriptionResponse>> DeleteAsync(string id)
        {
            return await _subscriptionService.DeleteAsync(id);
        }

        public async Task<Result<SubscriptionResponse>> ResumeAsync(string id)
        {
            return await _subscriptionService.ResumeAsync(id);
        }

        public async Task<Result<List<SubscriptionResponse>>> GetAllAsync()
        {
            return await _subscriptionService.GetAllAsync();
        }
    }

}