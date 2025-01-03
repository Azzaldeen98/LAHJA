using Infrastructure.DataSource.Seeds.Models;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsSubscriptionsData
    {
        private List<SubscriptionModel> subscriptions;

        public SeedsSubscriptionsData()
        {
            subscriptions = new List<SubscriptionModel>();
        }

        // Add a new subscription
        public void AddSubscription(SubscriptionModel subscription)
        {
            if (subscription == null)
                throw new ArgumentNullException(nameof(subscription));

            subscriptions.Add(subscription);
        }

        // Update an existing subscription by Id
        public bool UpdateSubscription(string id, SubscriptionModel updatedSubscription)
        {
            var subscription = subscriptions.FirstOrDefault(s => s.Id == id);
            if (subscription == null)
                return false;

            subscription.UserId = updatedSubscription.UserId;
            subscription.PlanId = updatedSubscription.PlanId;
            subscription.CustomerId = updatedSubscription.CustomerId;
            subscription.BillingPeriod = updatedSubscription.BillingPeriod;
            subscription.StartDate = updatedSubscription.StartDate;
            subscription.Status = updatedSubscription.Status;
            subscription.CancelAtPeriodEnd = updatedSubscription.CancelAtPeriodEnd;

            return true;
        }

        // Delete a subscription by Id
        public bool DeleteSubscription(string id)
        {
            var subscription = subscriptions.FirstOrDefault(s => s.Id == id);
            if (subscription == null)
                return false;

            subscriptions.Remove(subscription);
            return true;
        }

        // Search for subscriptions by a predicate
        public List<SubscriptionModel> SearchSubscriptions(Func<SubscriptionModel, bool> predicate)
        {
            return subscriptions.Where(predicate).ToList();
        }

        // Get all subscriptions (optional utility)
        public List<SubscriptionModel> GetAllSubscriptions()
        {
            return new List<SubscriptionModel>(subscriptions);
        }
    }
}
