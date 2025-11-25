namespace FaqAssistant.Entities;

public class FaqTag
{
    public int FaqId { get; set; }
    public Faq Faq { get; set; }

    public int TagId { get; set; }
    public Tag Tag { get; set; }
}
