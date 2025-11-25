using Microsoft.EntityFrameworkCore;
using FaqAssistant.Entities;

namespace FaqAssistant.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Faq> Faqs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<FaqTag> FaqTags { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);

        // Many-to-many
        mb.Entity<FaqTag>()
            .HasKey(ft => new { ft.FaqId, ft.TagId });

        mb.Entity<FaqTag>()
            .HasOne(ft => ft.Faq)
            .WithMany(f => f.FaqTags)
            .HasForeignKey(ft => ft.FaqId);

        mb.Entity<FaqTag>()
            .HasOne(ft => ft.Tag)
            .WithMany(t => t.FaqTags)
            .HasForeignKey(ft => ft.TagId);
    }
}
