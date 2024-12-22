using Domain.Entities.Plans.Response;
using LAHJA.Data.BlazarComponents.Plans.TemFeturePlans2.Them3.Model;

namespace LAHJA.Data.UI.Components.Category
{


    public class CategoryComponent
    {
        

        public string Id { get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public new List<SubscriptionPlanInfo>? SubscriptionsPlans { get; set; }



    }
}
