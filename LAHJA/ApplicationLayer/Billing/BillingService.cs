﻿using Application.UseCase.Plans;
using Application.UseCase.Plans.Get;
using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
using Domain.Entities.Payment;
using Domain.Entities.Payment.Request;
using Domain.Entities.Payment.Response;
using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;
using Domain.Wrapper;
using Infrastructure.Models.Profile.Response;

namespace Application.Services.Plans
{
    public class BillingClientService
    {
        private readonly BillingService billingService;

        public BillingClientService(BillingService billingService)
        {

            this.billingService = billingService;
        }


        public async Task<Result<BillingDetailsResponse>> GetBillingDetailsAsync()
        {
            return await billingService.GetBillingDetailsAsync();
        }
        public async Task<Result<BillingDetailsResponse>> CreateAsync(BillingDetailsRequest request)
        {
            return await billingService.CreateAsync(request);
        }
        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            return await billingService.DeleteAsync(id);
        }
        public async Task<Result<BillingDetailsResponse>> UpdateAsync(BillingDetailsRequest request)
        {
            return await billingService.UpdateAsync(request);
        }






    } 
}
