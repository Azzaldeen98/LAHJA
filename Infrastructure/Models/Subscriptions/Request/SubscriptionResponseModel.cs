using Domain.ShareData.Base.Response;
using Infrastructure.Models.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Subscriptions.Request
{
    public partial class SubscriptionResponseModel : BaseSubscriptionResponse
    {
        public SubscriptionPlanModel? Plan { get; set; }
    }




}
