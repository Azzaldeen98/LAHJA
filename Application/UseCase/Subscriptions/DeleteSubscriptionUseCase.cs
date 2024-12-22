using Domain.Entities.Subscriptions.Response;
using Domain.Repository.Subscriptions;
using Domain.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class DeleteSubscriptionUseCase
    {
        private readonly ISubscriptionsRepository repository;

        public DeleteSubscriptionUseCase(ISubscriptionsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<SubscriptionResponse>> ExecuteAsync(string id)
        {
            return await repository.DeleteAsync(id);
        }
    }






}
