using Domain.Entities.Billing.Request;
using Domain.Entities.Billing.Response;
using Domain.Repository.Billing;
using Domain.Wrapper;

namespace Application.Services.Plans
{
    public class CreateCreditCardUseCase
    {
        private readonly IBillingRepository repository;

        public CreateCreditCardUseCase(IBillingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<CardDetailsResponse>> ExecuteAsync(CardDetailsRequest request)
        {
        
            return await repository.CreateCardAsync(request);
        }
    }



}