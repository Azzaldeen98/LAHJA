using Application.UseCase.Plans.Get;
using Domain.Entities.Subscriptions.Response;
using Domain.Wrapper;


namespace Application.Services.Subscriptions
{
    public class SubscriptionService
    {
        private readonly PauseSubscriptionUseCase pauseSubscriptionUseCase;
        private readonly DeleteSubscriptionUseCase deleteSubscriptionUseCase;
        private readonly ResumeSubscriptionUseCase resumeSubscriptionUseCase;
        private readonly GetAllSubscriptionsUseCase getAllSubscriptionsUseCase;

        public SubscriptionService(
            PauseSubscriptionUseCase pauseSubscriptionUseCase,
            DeleteSubscriptionUseCase deleteSubscriptionUseCase,
            ResumeSubscriptionUseCase resumeSubscriptionUseCase,
            GetAllSubscriptionsUseCase getAllSubscriptionsUseCase)
        {
            this.pauseSubscriptionUseCase = pauseSubscriptionUseCase;
            this.deleteSubscriptionUseCase = deleteSubscriptionUseCase;
            this.resumeSubscriptionUseCase = resumeSubscriptionUseCase;
            this.getAllSubscriptionsUseCase = getAllSubscriptionsUseCase;
        }

        public async Task<Result<SubscriptionResponse>> PauseAsync(string id)
        {
            return await pauseSubscriptionUseCase.ExecuteAsync(id);
        }

        public async Task<Result<SubscriptionResponse>> DeleteAsync(string id)
        {
            return await deleteSubscriptionUseCase.ExecuteAsync(id);
        }

        public async Task<Result<SubscriptionResponse>> ResumeAsync(string id)
        {
            return await resumeSubscriptionUseCase.ExecuteAsync(id);
        }

        public async Task<Result<List<SubscriptionResponse>>> GetAllAsync()
        {
            return await getAllSubscriptionsUseCase.ExecuteAsync();
        }
    }

}
