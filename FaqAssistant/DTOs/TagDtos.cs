namespace FaqAssistant.Api.Dtos
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TagCreateDto
    {
        public string Name { get; set; }
    }

    public class TagUpdateDto
    {
        public string Name { get; set; }
    }
}
