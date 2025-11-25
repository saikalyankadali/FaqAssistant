namespace FaqAssistant.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<FaqTag> FaqTags { get; set; }
}
