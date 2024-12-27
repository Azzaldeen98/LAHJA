﻿using LAHJA.Data.UI.Components.Billing.BillingHeader;
using LAHJA.Data.UI.Components.Payment.BillingContact;
using LAHJA.Data.UI.Components.Payment.CreditCard;

namespace LAHJA.Data.UI.Billing
{
    public class DataBuildBilling
    {


        public HeaderComponent HeaderComponent { get; set; }=null;
        public List<CardDetails> CardDetails { get; set; } = null;
        public BillingContact BillingContact { get; set; } = null;
        public List<InvoiceBilling> InvoiceBilling { get; set; } = null;
        public LastPaymentt Lastpayment { get; set; } = null;
        public List<PieChartModel> pieChartModel { get; set; } = null;











    }
}