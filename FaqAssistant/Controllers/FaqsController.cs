using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FaqAssistant.Data;
using FaqAssistant.Entities;

[ApiController]
[Route("api/[controller]")]
public class FaqsController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public FaqsController(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? search)
    {
        IQueryable<Faq> query = _db.Faqs
            .Include(f => f.Category)
            .Include(f => f.FaqTags).ThenInclude(ft => ft.Tag)
            .Include(f => f.CreatedByUser);

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(f => f.Question.Contains(search));

        var faqs = await query.ToListAsync();

        return Ok(_mapper.Map<IEnumerable<FaqResponseDto>>(faqs));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var faq = await _db.Faqs
            .Include(f => f.Category)
            .Include(f => f.FaqTags).ThenInclude(ft => ft.Tag)
            .Include(f => f.CreatedByUser)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (faq == null) return NotFound();
        return Ok(_mapper.Map<FaqResponseDto>(faq));
    }

    [HttpPost]
    public async Task<IActionResult> Create(FaqCreateDto dto)
    {
        var faq = new Faq
        {
            Question = dto.Question,
            Answer = dto.Answer,
            CategoryId = dto.CategoryId,
            CreatedByUserId = dto.CreatedByUserId,
            CreatedAt = DateTime.UtcNow
        };

        _db.Faqs.Add(faq);
        await _db.SaveChangesAsync();

        if (dto.TagIds.Any())
        {
            foreach (var tagId in dto.TagIds)
            {
                _db.FaqTags.Add(new FaqTag { FaqId = faq.Id, TagId = tagId });
            }
            await _db.SaveChangesAsync();
        }

        return Ok(_mapper.Map<FaqResponseDto>(faq));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, FaqUpdateDto dto)
    {
        var faq = await _db.Faqs.Include(f => f.FaqTags).FirstOrDefaultAsync(f => f.Id == id);
        if (faq == null) return NotFound();

        faq.Question = dto.Question;
        faq.Answer = dto.Answer;
        faq.CategoryId = dto.CategoryId;
        faq.UpdatedByUserId = dto.UpdatedByUserId;
        faq.UpdatedAt = DateTime.UtcNow;

        _db.FaqTags.RemoveRange(faq.FaqTags);
        await _db.SaveChangesAsync();

        foreach (var tagId in dto.TagIds)
            _db.FaqTags.Add(new FaqTag { FaqId = id, TagId = tagId });

        await _db.SaveChangesAsync();
        return Ok(_mapper.Map<FaqResponseDto>(faq));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var faq = await _db.Faqs.FindAsync(id);
        if (faq == null) return NotFound();

        _db.Faqs.Remove(faq);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
