using AutoMapper;
using FaqAssistant.Api.Dtos;
using FaqAssistant.Data;
using FaqAssistant.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FaqAssistant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TagsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDto>>> GetTags()
        {
            var tags = await _context.Tags.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TagDto>>(tags));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagDto>> GetTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null) return NotFound();

            return Ok(_mapper.Map<TagDto>(tag));
        }

        [HttpPost]
        public async Task<ActionResult<TagDto>> Create(TagCreateDto dto)
        {
            var tag = _mapper.Map<Tag>(dto);
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTag),
                new { id = tag.Id },
                _mapper.Map<TagDto>(tag));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TagUpdateDto dto)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null) return NotFound();

            _mapper.Map(dto, tag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null) return NotFound();

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
