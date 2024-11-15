namespace e_commerceApp.Shared.Models
{
    public static class Initials
    {
        public const string Role_User_Indi = "Individual";
        public const string Role_User_Comp = "Company";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
        public const string PaymentStatusRejected = "Rejected";

        public const string SessionCart = "SessionShoppingCart";

        public const string Success = "Success";
        public const string Created = "Created";
        public const string NoContent = "NoContent";
        public const string BadRequest = "BadRequest";
        public const string Unauthorized = "Unauthorized";
        public const string Forbidden = "Forbidden";
        public const string NotFound = "NotFound";
        public const string InternalServerError = "InternalServerError";
        public const string DuplicateResource = "DuplicateResource";
        public const string InvalidCredentials = "InvalidCredentials";
        public const string ResourceAlreadyExists = "ResourceAlreadyExists";
    }
}
