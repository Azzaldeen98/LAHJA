
using AutoMapper;
using Domain.Entities.Payment;
using Domain.Entities.Payment.Response;
using Domain.Entities.Plans.Response;
using Domain.Repository.Payment;
using Domain.ShareData.Base;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClient.Payment;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Payment.Request;
using Infrastructure.Models.Payment.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using Infrastructure.Nswag;
using Shared.Settings;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace Infrastructure.Repository.Plans
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly PaymentApiClient paymentApiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public PaymentRepository(
            IMapper mapper,
            SeedsPlans seedsPlans,
            ApplicationModeService appModeService,
            PaymentApiClient paymentApiClient)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;

            this.paymentApiClient = paymentApiClient;
        }



        public async Task<Result<PaymentCheckoutResponse>> getPaymentCheckoutPage(PaymentCheckoutRequest request)
        {
            var model = _mapper.Map<PaymentCheckoutRequestModel>(request);
            var response = await ExecutorAppMode.ExecuteAsync<Result<PaymentCheckoutResponseModel>>(
                 async () => await paymentApiClient.getPaymentCheckOut(model),
                  async () => Result<PaymentCheckoutResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<PaymentCheckoutResponse>(response.Data) : null;
                return Result<PaymentCheckoutResponse>.Success(result);
            }
            else
            {
                return Result<PaymentCheckoutResponse>.Fail(response.Messages);
            }



        }

        public async Task<Result<PaymentCheckoutResponse>> getPaymentCheckOut(SessionCreate request)
        {

            {
                var model = _mapper.Map<SessionCreateModel>(request);
                var response = await ExecutorAppMode.ExecuteAsync<Result<PaymentCheckoutResponseModel>>(
                     async () => await paymentApiClient.getPaymentCheckOutManage(model),
                      async () => Result<PaymentCheckoutResponseModel>.Success());

                if (response.Succeeded)
                {
                    var result = (response.Data != null) ? _mapper.Map<PaymentCheckoutResponse>(response.Data) : null;
                    return Result<PaymentCheckoutResponse>.Success(result);
                }
                else
                {
                    return Result<PaymentCheckoutResponse>.Fail(response.Messages);
                }
            }



        }
   



    } 
}
