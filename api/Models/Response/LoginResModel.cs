namespace api.Models.Response
{
    public class LoginResModel
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
    }
}
