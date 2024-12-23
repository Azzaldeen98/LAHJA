﻿namespace Domain.ShareData.Base.Billing
{
    public class CardDetailsBase
    {
 

        public string? CardNumber { get; set; }
        public string? Email { get; set; }

        public string? ExpirationDate { get; set; }

        public string? Cvc { get; set; }

        public string? CardType { get; set; }

        public bool IsSelected { get; set; }
    }
}