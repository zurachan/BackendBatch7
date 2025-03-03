namespace BackendBatch7.Domain.Response
{
    public class UserModel
    {
        public int Id { get; set; }
        public string First_name { get; set; } = string.Empty;
        public string Last_name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
