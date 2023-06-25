using Extensions;
using HiredServices.Domain.Models;
using Services.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<HiredService> HiredServices { get; set; }
        
        protected readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
     
            //Service Entity
            builder.Entity<Service>().ToTable("Services");
            builder.Entity<Service>().HasKey(p => p.Id);
            builder.Entity<Service>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Service>().Property(p => p.Name).IsRequired().HasMaxLength(35);
            builder.Entity<Service>().Property(p => p.Score);
            builder.Entity<Service>().Property(p => p.Price).IsRequired();
            builder.Entity<Service>().Property(p => p.NewPrice);
            builder.Entity<Service>().Property(p => p.Location).IsRequired();
            builder.Entity<Service>().Property(p => p.CreationDate).IsRequired();
            builder.Entity<Service>().Property(p => p.Photos).HasMaxLength(500);
            builder.Entity<Service>().Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Entity<Service>().Property(p => p.IsOffer);

            //Constrains
            builder.Entity<HiredService>().ToTable("HiredServices");
            builder.Entity<HiredService>().HasKey(p => p.Id);
            builder.Entity<HiredService>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<HiredService>().Property(p => p.Amount).IsRequired();
            builder.Entity<HiredService>().Property(p => p.Price).IsRequired();
            builder.Entity<HiredService>().Property(p => p.ScheduledDate).IsRequired().HasMaxLength(15);
            builder.Entity<HiredService>().Property(p => p.Status).IsRequired().HasMaxLength(30);


            builder.UseSnakeCaseNamingConventions();
        }
        
    }
}