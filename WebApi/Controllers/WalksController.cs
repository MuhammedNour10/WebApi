using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.CustomActionFilters;
using WebApi.Models.Domain;
using WebApi.Models.DTO;
using WebApi.Repository.IRepository;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WalksController:Controller{
    private readonly IWalkRepository walkRepository;
    private readonly IMapper mapper;
public WalksController(IWalkRepository walkRepository,IMapper mapper)
{
        this.walkRepository = walkRepository;
        this.mapper = mapper;
    
}
[HttpGet]
public async Task<IActionResult> Index(
[FromQuery]string?filterOn,
[FromQuery]string?filterQuery,
[FromQuery]string?sortedBy,
[FromQuery] bool? isAsend
)

{

        var walkList = await walkRepository.GetAllWalksAysnc(filterOn,filterQuery,sortedBy,isAsend??true);


       var walksDto= mapper.Map<List<WalksDto>>(walkList);
          
        return Ok(walksDto);

}

[HttpGet("{id:guid}")]
public async Task<IActionResult> GetById([FromRoute]Guid id){

        var walkModel= await walkRepository.GetByIdAysnc(id);

               
       var walksDto= mapper.Map<WalksDto>(walkModel);
          
        return Ok(walksDto);

}

[HttpPost]
[ValidateModel]
public async Task<IActionResult> Create([FromBody] AddWalkDto addWalkDto){
    
        var walkModels=mapper.Map<Walks>(addWalkDto);

        await walkRepository.AddWalkAysnc(walkModels);

        return Ok(mapper.Map<WalksDto>(walkModels));
      

}

[HttpPut]
[Route("{id:guid}")]
[ValidateModel]
public async Task <IActionResult> Edit([FromRoute]Guid id,[FromBody]UpdateWalkDto updateWalkDto){
  

       var walkModels= mapper.Map<Walks>(updateWalkDto);

        if (walkModels == null)
            return NotFound();

       walkModels=await  walkRepository.UpdateAysn(id,walkModels);

        return Ok(mapper.Map<WalksDto>(walkModels));
}


[HttpDelete("{id:guid}")]
public async Task <IActionResult> Delete([FromRoute] Guid id){
     
 var walkModels =await  walkRepository.GetByIdAysnc(id);

        if (walkModels == null)
            return NotFound();

       await  walkRepository.RemoveAysnc(walkModels);

        return Ok(mapper.Map<WalksDto>(walkModels));
} 








}