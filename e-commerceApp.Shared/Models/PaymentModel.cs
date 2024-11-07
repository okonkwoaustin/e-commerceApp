using System.ComponentModel.DataAnnotations;
namespace e_commerceApp.Shared.Models
{
    public class PaymentModel
    { 
            [Key]
            public Guid PaymentId { get; set; } = Guid.NewGuid();

            [Required]
            public string UserId { get; set; } 

            [Required]
            public decimal Amount { get; set; }

            [Required]
            public string Currency { get; set; } = "NGN";

            [Required]
            public string PaymentProvider { get; set; } = "PayPal";  // Could be "Stripe", "PayPal", etc.

            public string ProviderPaymentId { get; set; }  // PayPal OrderId or other provider's payment ID

            [Required]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime? CompletedAt { get; set; }  // Filled only when payment is successful

            [Required]
            public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

            public string? FailureReason { get; set; }  // Optional field to capture any failure reason
        public enum PaymentStatus
        {
            Pending,
            Completed,
            Failed,
            Refunded
        }
    }
}
