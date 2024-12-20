﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Price.Response
{
    public partial class PriceResponse
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public bool Active { get; set; }
        public string Currency { get; set; }
        public string Interval { get; set; }
        public double UnitAmountDecimal { get; set; }
        public long UnitAmount { get; set; }
    }
}