using WebApi.Models.Domain;

namespace WebApi.Repository.IRepository;


public interface IImageRepository{


    Task<Image> Upload(Image image);


}