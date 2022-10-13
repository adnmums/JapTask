namespace Platform.Core.Requests.User
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? BirhtDate { get; set; }
    }
}
