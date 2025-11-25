namespace FaqAssistant.Entities;

public class User
{
    public int Id { get; set; }
    public string DisplayName { get; set; }

    public ICollection<Faq> CreatedFaqs { get; set; }
    public ICollection<Faq> UpdatedFaqs { get; set; }
}
