using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApi.Models.Domain;

namespace WebApi.Data;

public class ApplicationDbContext:DbContext{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }

    public DbSet<Walks> Walks{ get; set; }
    public DbSet<Difficulty> Difficulties{ get; set; }
    public DbSet<Regions> Regions{ get; set; }
    public DbSet<Image> Images{ get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var difficulties = new List<Difficulty>()
        { 
            new Difficulty(){
                Id=Guid.NewGuid(),
                Name="Easy"
            },
               new Difficulty(){
                Id=Guid.NewGuid(),
                Name="Medium"
            },
               new Difficulty(){
                Id=Guid.NewGuid(),
                Name="Hard"
            },

        };
        
//seed data add data to Dificulties table
        modelBuilder.Entity<Difficulty>().HasData(difficulties);


         // Seed data for Regions
            var regions = new List<Regions>
            {
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Regions
                {
                    Id = Guid.NewGuid(),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            modelBuilder.Entity<Regions>().HasData(regions);
    }

}