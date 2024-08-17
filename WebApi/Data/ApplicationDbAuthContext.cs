using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace WebApi.Data;


public class ApplicationDbAuthContext:IdentityDbContext{
    public ApplicationDbAuthContext(DbContextOptions<ApplicationDbAuthContext> options):base(options)
    {
      

        
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

   var readerRoleId = "d271f9b6-8d6b-4c2e-93ff-4f8e32a8b3b0";
      var writerRoleId = "a9e5b1c2-53c5-47e1-9460-958d1d7bda42";
        var roles = new List<IdentityRole>()
        {
        new IdentityRole(){
            Id=readerRoleId,
            ConcurrencyStamp=readerRoleId,
            Name="Reader",
            NormalizedName="Reader".ToUpper()
        },

            new IdentityRole(){
            Id=writerRoleId,
            ConcurrencyStamp=writerRoleId,
            Name="Writer",
            NormalizedName="Writer".ToUpper()
        }


        };

        builder.Entity<IdentityRole>().HasData(roles);
    }

}