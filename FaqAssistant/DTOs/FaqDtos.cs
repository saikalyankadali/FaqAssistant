public class FaqCreateDto
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public int CategoryId { get; set; }
    public List<int> TagIds { get; set; }
    public int CreatedByUserId { get; set; }
}

public class FaqUpdateDto
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public int CategoryId { get; set; }
    public List<int> TagIds { get; set; }
    public int UpdatedByUserId { get; set; }
}

public class FaqResponseDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }

    public string Category { get; set; }
    public List<string> Tags { get; set; }
    public string CreatedBy { get; set; }
}
