using System.ComponentModel.DataAnnotations;
namespace e_commerceApp.Shared.Models
{
    public class PaymentModel
    { 
            [Key]
            public string PaymentId { get; set; } = Guid.NewGuid().ToString();

        [Required]
            public string UserId { get; set; } 

            [Required]
            public decimal Amount { get; set; }

            [Required]
            public string Currency { get; set; } = "NGN";

            [Required]
            public string PaymentProvider { get; set; } = "Stripe";  

            public string ProviderPaymentId { get; set; }

            [Required]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime? CompletedAt { get; set; }  

            [Required]
            public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

            public string? FailureReason { get; set; }  
        public enum PaymentStatus
        {
            Pending,
            Completed,
            Failed,
            Refunded
        }
    }
}
