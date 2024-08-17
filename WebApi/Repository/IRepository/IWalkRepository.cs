using System.Xml.Serialization;
using WebApi.Models.Domain;

namespace WebApi.Repository.IRepository;

public interface IWalkRepository{
    public Task<List<Walks>> GetAllWalksAysnc(string?filterOn=null,string?filterQuery=null,string?sortedBy=null,bool?isAsend=true);

    public Task<Walks?> GetByIdAysnc(Guid id);

    public Task AddWalkAysnc(Walks walk);

    public Task<Walks?> UpdateAysn(Guid id,Walks walks);

    public Task RemoveAysnc(Walks walk);
    
}