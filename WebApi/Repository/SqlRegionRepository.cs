using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.Domain;

namespace WebApi.Repository.IRepository;


public class SqlRegionRepository : IRegionRepository


{

    private readonly ApplicationDbContext _context;
    public SqlRegionRepository(ApplicationDbContext context)
    {
        _context = context;
        
    }
    public async Task<List<Regions>> GetAllAysnc()
    {
        return await _context.Regions.ToListAsync();
        
    }

    public async Task<Regions?> GetByIdAysnc(Guid id)
    {
        return await  _context.Regions.FindAsync(id);
        
            
    }


    public async Task AddAysnc(Regions region)
    {
        await _context.Regions.AddAsync(region);
        await _context.SaveChangesAsync();
    }

    public async Task<Regions?> UpdateAysnc(Guid id,Regions region)
    {
        var existRegion = await _context.Regions.FindAsync(id);

         if(existRegion!=null){

        existRegion.Name = region.Name;
        existRegion.RegionImageUrl = region.RegionImageUrl;
        existRegion.Code = region.Code;
      
        await _context.SaveChangesAsync();
            return existRegion;
         }
        return null;
        
    }

    public async Task Remove(Regions region)
    {
      
       if(region!=null){
         _context.Regions.Remove(region);
        await _context.SaveChangesAsync();
       }
        
    }

    
}