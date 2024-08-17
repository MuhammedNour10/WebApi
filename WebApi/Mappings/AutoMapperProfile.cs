using AutoMapper;
using WebApi.Models.Domain;
using WebApi.Models.DTO;

namespace WebApi.Mappings;


public class AutoMapperProfile:Profile{

  public AutoMapperProfile()
  {
        CreateMap<Regions, RegionsDTO>().ReverseMap();
        CreateMap<AddRegionRequestDto, Regions>().ReverseMap();
        CreateMap<UpdateRegionRequestDto, Regions>().ReverseMap();
        CreateMap<Walks, WalksDto>().ReverseMap();
    CreateMap<AddWalkDto, Walks>().ReverseMap();
    CreateMap<UpdateWalkDto, Walks>().ReverseMap();
    
    
  }
}