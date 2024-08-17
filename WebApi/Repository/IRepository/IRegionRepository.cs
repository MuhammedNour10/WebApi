using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Domain;

namespace WebApi.Repository.IRepository;


public interface IRegionRepository{

   Task <List<Regions>> GetAllAysnc();

    Task<Regions?> GetByIdAysnc(Guid id);
    Task AddAysnc(Regions region);

    Task <Regions?>  UpdateAysnc(Guid id,Regions region);

    Task Remove(Regions region);    

}