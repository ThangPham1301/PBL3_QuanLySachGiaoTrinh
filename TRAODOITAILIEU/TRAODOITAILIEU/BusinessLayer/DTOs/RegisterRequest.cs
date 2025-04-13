namespace TRAODOITAILIEU.BusinessLayer.DTOs
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birth { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
