using Domain.Repository.Billing;
using Domain.ShareData.Base;
using Domain.Wrapper;

namespace Application.Services.Plans
{
    public class DeleteCreditCardUseCase
    {
        private readonly IBillingRepository repository;

        public DeleteCreditCardUseCase(IBillingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<DeleteResponse>> ExecuteAsync(string cardId)
        {
   
            return await repository.DeleteBillingAsync(cardId);
        }
    }



}