﻿using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models.Plans;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsSubscriptionsData
    {
        private List<SubscriptionModel> subscriptions;

        public SeedsSubscriptionsData()
        {
           

          subscriptions = new List<SubscriptionModel>
        {
            new SubscriptionModel
            {
                Id = "1",
                UserId = "test@gmail.com",
                PlanId = "price_1Pst3IKMQ7LabgRTZV9VgPex",
                CustomerId = "customer_001",
                BillingPeriod = "Monthly",
                StartDate = DateTime.Now,
                Status = "Active",
                CancelAtPeriodEnd = false,
                SubscriptionPlan =   new SubscriptionPlanModel
                    {
                        Id = "price_1Pst3IKMQ7LabgRTZV9VgPex",
                        Name = "Free",
                        Description = "Basic subscription plan",
                        Active = true,
                        Price = 0m,
                        IsFixed = false,
                        IsPaid = false,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 0m,
                        ContainerId = "1",
                        TotalBilling = 08m,
                        Image = "basic-plan.png",
                        MonthlyPrice = 0m,
                        AnnualPrice = 0m,
                        WeeklyPrice = 0m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "AI Models", Description = "3", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "Requests", Description = "1,000 requests", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "Processor", Description = "Shared", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "RAM", Description = "2 GB", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Speed", Description = "2 pre/Second", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "Support", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "7", Name = "Customization", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "1", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                        }
                    }
            },
            new SubscriptionModel
            {
                Id = "2",
                UserId = "user_002",
                PlanId = "plan_002",
                CustomerId = "customer_002",
                BillingPeriod = "Yearly",
                StartDate = DateTime.Now,
                Status = "Active",
                CancelAtPeriodEnd = true,
                SubscriptionPlan =  new SubscriptionPlanModel
                    {
                        Id = "price_1Pst3IKMQ7LabgRTZV9VgPex",
                        Name = "Free",
                        Description = "Basic subscription plan",
                        Active = true,
                        Price = 0m,
                        IsFixed = false,
                        IsPaid = false,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 0m,
                        ContainerId = "1",
                        TotalBilling = 08m,
                        Image = "basic-plan.png",
                        MonthlyPrice = 0m,
                        AnnualPrice = 0m,
                        WeeklyPrice = 0m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "AI Models", Description = "3", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "Requests", Description = "1,000 requests", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "Processor", Description = "Shared", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "RAM", Description = "2 GB", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Speed", Description = "2 pre/Second", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "Support", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "7", Name = "Customization", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "1", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                        }
                    }
            },
            new SubscriptionModel
            {
                Id = "3",
                UserId = "user_003",
                PlanId = "plan_003",
                CustomerId = "customer_003",
                BillingPeriod = "Monthly",
                StartDate =DateTime.Now,
                Status = "Pending",
                CancelAtPeriodEnd = false,
                SubscriptionPlan =  new SubscriptionPlanModel
                    {
                        Id = "price_1Pst3IKMQ7LabgRTZV9VgPex",
                        Name = "Free",
                        Description = "Basic subscription plan",
                        Active = true,
                        Price = 0m,
                        IsFixed = false,
                        IsPaid = false,
                        Quantity = 1,
                        BillingPeriod = "Monthly",
                        TotalAmount = 0m,
                        ContainerId = "1",
                        TotalBilling = 08m,
                        Image = "basic-plan.png",
                        MonthlyPrice = 0m,
                        AnnualPrice = 0m,
                        WeeklyPrice = 0m,
                        Features = new List<PlanFeatureModel>
                        {
                            new PlanFeatureModel { Id = "1", Name = "AI Models", Description = "3", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "2", Name = "Requests", Description = "1,000 requests", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "3", Name = "Processor", Description = "Shared", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "4", Name = "RAM", Description = "2 GB", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "5", Name = "Speed", Description = "2 pre/Second", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                            new PlanFeatureModel { Id = "6", Name = "Support", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "7", Name = "Customization", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "8", Name = "API", Description = "No", BillingPeriod = "Monthly", TotalAmount = 0m, Active = false },
                            new PlanFeatureModel { Id = "9", Name = "Space", Description = "1", BillingPeriod = "Monthly", TotalAmount = 0m, Active = true },
                        }
                    }
            }
        };
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
            return subscriptions.Where(predicate).OrderDescending().ToList();
        }

        public List<SubscriptionModel>? getActiveSubscriptions(string userId)
        {
            return subscriptions.Where(x => x.UserId == userId && x?.SubscriptionPlan?.Active==true)?.OrderDescending()?.ToList();
          
        }

        public List<SubscriptionModel>? getAllUserSubscriptions(string userId)
        {
            return subscriptions.Where(x => x.UserId == userId)?.OrderDescending()?.ToList();

        }

        // Get all subscriptions (optional utility)
        public List<SubscriptionModel> GetAllSubscriptions()
        {
            return new List<SubscriptionModel>(subscriptions);
        }
    }
}