namespace FaqAssistant.Api.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }

    public class UserCreateDto
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }

    public class UserUpdateDto
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
