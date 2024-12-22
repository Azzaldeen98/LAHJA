namespace Domain.ShareData.Base.Request
{
    public class BaseConfirmEmailRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }

        public string ChangedEmail { get; set; }
    }
}
