namespace api.Models.Request
{
    public class UpdatePasswordReqModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
