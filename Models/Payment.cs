﻿namespace E_commerce.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string PaymentIntentId { get; set; } 
        public string Status { get; set; } 
        public DateTime PaidAt { get; set; }
    }
}
