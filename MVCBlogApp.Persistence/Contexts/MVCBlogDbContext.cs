using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Domain.Entities;
using MVCBlogApp.Domain.Entities.Common;
using MVCBlogApp.Domain.Entities.Identity;
using System.Reflection.Emit;

namespace MVCBlogApp.Persistence.Contexts
{
    public class MVCBlogDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MVCBlogDbContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Blog> Blogs { get; set; }
        DbSet<BlogCategory> BlogCategories { get; set; }
        DbSet<BlogCategoryRelationship> BlogCategoryRelationships { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entityler üzerinden yapılan değişiklikleri ya da yeni eklenen verinin yakalanmasını sağlayan propertdir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.
            var datas = ChangeTracker
                .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Blog

            builder.Entity<BlogCategoryRelationship>()
                .HasKey(ky => new { ky.BlogID, ky.BlogCategoryID });

            builder.Entity<BlogCategoryRelationship>()
                .HasOne(s => s.Blog)
                .WithMany(u => u.Categories)
                .HasForeignKey(s => s.BlogID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<BlogCategoryRelationship>()
              .HasOne(s => s.BlogCategory)
              .WithMany(u => u.Blogs)
              .HasForeignKey(s => s.BlogCategoryID)
              .OnDelete(DeleteBehavior.ClientSetNull);


            #endregion


            base.OnModelCreating(builder);
        }
    }
}
