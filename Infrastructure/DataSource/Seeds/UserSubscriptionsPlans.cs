using Infrastructure.Models.Plans;
using Infrastructure.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.Seeds
{
    public class SeedsUserSubscriptionsPlans
    {


		private List<SubscriptionPlanModel> _plans = new List<SubscriptionPlanModel>();

		public SeedsUserSubscriptionsPlans()
		{
			var basicPlan = new SubscriptionPlanModel
			{
				Id = "1",
				Name = "الخطة العامة (Basic Plan)",
				Description = "خطة اشتراك أساسية",
				Active = true,
				User = new UserModel { Id = "1", Email = "test@gmail.com" },
				Price = 9.99m,
				IsFixed = false,
				IsPaid = true,
				Quantity = 1,
				BillingPeriod = "Monthly",
				TotalAmount = 9.99m,
				ContainerId = "1",
				TotalBilling = 119.88m,
				Image = "basic-plan.png",
				MonthlyPrice = 9.99m,
				AnnualPrice = 99.99m,
				WeeklyPrice = 2.49m,
				Features = new List<PlanFeatureModel>
			{
				new PlanFeatureModel { Id = "1", Name = "Requests", Description = "1,000 طلب", BillingPeriod = "Monthly", NumberRequests = 1000, TotalAmount = 9.99m, Active = true },
				new PlanFeatureModel { Id = "2", Name = "CPU", Description = "مشترك مع خوادم أخرى", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
				new PlanFeatureModel { Id = "3", Name = "RAM", Description = "4 جيجابايت", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
				new PlanFeatureModel { Id = "4", Name = "Speed (Response Time)", Description = "متوسط 2 ثانية لكل طلب", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true },
				new PlanFeatureModel { Id = "5", Name = "Support", Description = "دعم عبر البريد الإلكتروني فقط", BillingPeriod = "Monthly", TotalAmount = 9.99m, Active = true }
			}
			};

			_plans.Add(basicPlan);
		}

		// Add a new subscription plan
		public void AddPlan(SubscriptionPlanModel plan)
		{
			if (_plans.Any(p => p.Id == plan.Id))
			{
				throw new Exception("Plan with the same Id already exists.");
			}
			_plans.Add(plan);
			Console.WriteLine("Plan added successfully.");
		}

		// Update an existing subscription plan
		public void UpdatePlan(string id, SubscriptionPlanModel updatedPlan)
		{
			var plan = _plans.FirstOrDefault(p => p.Id == id);
			if (plan == null)
			{
				throw new Exception("Plan not found.");
			}
			_plans.Remove(plan);
			_plans.Add(updatedPlan);
			Console.WriteLine("Plan updated successfully.");
		}

		// Delete a subscription plan
		public void DeletePlan(string id)
		{
			var plan = _plans.FirstOrDefault(p => p.Id == id);
			if (plan == null)
			{
				throw new Exception("Plan not found.");
			}
			_plans.Remove(plan);
			Console.WriteLine("Plan deleted successfully.");
		}

		// Retrieve all plans
		public List<SubscriptionPlanModel> GetAllSubscriptionsPlansByEmail(string email)
		{
			return _plans.Where(x=>x.User?.Email== email).ToList();
		}
		public List<SubscriptionPlanModel> GetAllSubscriptionsPlansById(string userId)
		{
			return _plans.Where(x => x.User?.Id == userId).ToList();
		}

		// Find a plan by Id
		public SubscriptionPlanModel GetPlanById(string id)
		{
			var plan = _plans.FirstOrDefault(p => p.Id == id);
			if (plan == null)
			{
				throw new Exception("Plan not found.");
			}
			return plan;
		}
	

	

}
}
