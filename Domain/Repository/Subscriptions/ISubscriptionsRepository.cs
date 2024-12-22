using Domain.Entities.Product.Request;
using Domain.Entities.Product.Response;
using Domain.Entities.Subscriptions.Response;
using Domain.ShareData.Base;
using Domain.Wrapper;


namespace Domain.Repository.Subscriptions
{
    public interface ISubscriptionsRepository
    {

        Task<Result<SubscriptionResponse>> DeleteAsync(string id);
        Task<Result<SubscriptionResponse>> ResumeAsync(string id);
        Task<Result<SubscriptionResponse>> PauseAsync(string id);
        Task<Result<List<SubscriptionResponse>>> getAllAsync();
    }
}