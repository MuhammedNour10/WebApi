using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

using WebApi.Models.Domain;
using WebApi.Repository.IRepository;

namespace WebApi.Repository;

public class WalkRepository : IWalkRepository
{
    private readonly ApplicationDbContext context;
    public WalkRepository(ApplicationDbContext context)
    {
        this.context = context;
        
    }
    public async Task AddWalkAysnc(Walks walk)
    {
      await context.Walks.AddAsync(walk);
        await context.SaveChangesAsync();
        
    }

    public async Task<List<Walks>> GetAllWalksAysnc(string?filterOn=null,string?filterQuery=null,string?sortedBy=null,bool?Asend=true)
    {

        var walk = context.Walks.Include(u => u.Region).Include(u => u.Difficulty).AsQueryable();

          if(!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
          {

           if(filterOn.Equals("Name",StringComparison.OrdinalIgnoreCase)){

                walk = walk.Where(u => u.Name.Contains(filterQuery));
           }

          }

          if(!string.IsNullOrWhiteSpace(sortedBy)){
              
              if(sortedBy.Equals("Name",StringComparison.OrdinalIgnoreCase)){

                walk = Asend==true? walk.OrderBy(u => u.Name):walk.OrderByDescending(u=>u.Name);
              }



          }

        return await walk.ToListAsync();
                
    }

    public async Task<Walks?> GetByIdAysnc(Guid id)
    {

        return await context.Walks.Include("Region").Include("Difficulty").FirstAsync(u=>u.Id==id);
               
    }

    

    public async Task RemoveAysnc(Walks walk)
    {

         
             
        context.Walks.Remove(walk);
        await context.SaveChangesAsync();

        
    }

    public async Task <Walks?> UpdateAysn(Guid id, Walks walks)
    {
        var existWalk = await context.Walks.FindAsync(id);

       if(existWalk!=null){

        existWalk.Name = walks.Name;
        existWalk.Description = walks.Description;
        existWalk.WalkImageUrl = walks.WalkImageUrl;
        existWalk.DifficultyId = walks.DifficultyId;
        existWalk.RegionId = walks.RegionId;

           
        await context.SaveChangesAsync();
            return existWalk;
       }

        return null;
     

    }

   
}