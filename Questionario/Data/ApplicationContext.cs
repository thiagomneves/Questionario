using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Questionario.Domain;

namespace Questionario.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Form> Forms{ get; set; }
        public DbSet<Answer> Answers{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(value => { 
                value.Property(p => p.Name).IsRequired();
                value.Property(p => p.Email).IsRequired();
                value.Property(p => p.Password).IsRequired();
                value.HasMany(ssc => ssc.Answers).WithOne(s => s.User).HasForeignKey(ssc => ssc.Id);
            });

            builder.Entity<Admin>(value => {
                value.Property(p => p.Name).IsRequired();
                value.Property(p => p.Email).IsRequired();
                value.Property(p => p.Password).IsRequired();
                value.HasMany(ssc => ssc.Forms).WithOne(s => s.Admin).HasForeignKey(ssc => ssc.Id);
            });

            builder.Entity<Form>(value => {
                value.Property(p => p.Answers).HasMaxLength(300000);
                value.HasOne(p => p.Admin).WithMany(p => p.Forms).HasForeignKey(p => p.AdminId);
                value.HasMany(ssc => ssc.Answers).WithOne(s => s.Form).HasForeignKey(ssc => ssc.Id);
            });

            builder.Entity<Answer>(value => {
                value.HasKey(p => new {p.FormId, p.UserId});
                value.Property(p => p.Answers).HasMaxLength(300000).IsRequired();
                value.HasOne(p => p.Form).WithMany(p => p.Answers).HasForeignKey(p => p.FormId);
                value.HasOne(p => p.User).WithMany(p => p.Answers).HasForeignKey(p => p.UserId);
            });
        }
    }
}
