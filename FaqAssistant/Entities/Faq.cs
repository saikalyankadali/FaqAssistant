namespace FaqAssistant.Entities;

public class Faq
{
    public int Id { get; set; }

    public string Question { get; set; }
    public string Answer { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; }

    public int? UpdatedByUserId { get; set; }
    public User? UpdatedByUser { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<FaqTag> FaqTags { get; set; }
}
