using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.CustomActionFilters;
using WebApi.Data;
using WebApi.Models.Domain;
using WebApi.Models.DTO;
using WebApi.Repository;
using WebApi.Repository.IRepository;

namespace WebApi.Controllers;
//https:\\localhost:number/api/region

[Route("api/[controller]")]
[ApiController]

public class RegionsController:Controller{
    private readonly IRegionRepository _regionRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<RegionsController> _logger;

    public RegionsController(IRegionRepository regionRepository, IMapper mapper,ILogger<RegionsController>
     logger
    )
    {
        _regionRepository = regionRepository;
        _mapper = mapper;
        _logger = logger;

        
    }


    [HttpGet]
    public async Task<IActionResult> GetAllRegion() {
        //get data from Domain Models

         
            var regions = await _regionRepository.GetAllAysnc();

        //map Domain modles To DBo

       var regionsDto=_mapper.Map<List<RegionsDTO>>(regions);
 
       //Return DTO
        return Ok(new { data=regionsDto });  
       
      

   
     }
     [HttpGet]
     [Route("{id:guid}")]
     public async Task<IActionResult> GetById([FromRoute]Guid id){
        //  Get data from database {domain Models}
        var regionModel = await _regionRepository.GetByIdAysnc(id);
        if (regionModel == null)
            return NotFound();

        //Map region Models to Dto

        var regionDto=_mapper.Map<RegionsDTO>(regionModel);



        return Ok(regionDto);

     }


   [HttpPost]
   [ValidateModel]
    public async Task <IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto){

        //convert from Dto To Region Model

       

    var regionDomainModel= _mapper.Map<Regions>(addRegionRequestDto);

        //use domain Model to Create Region 
        await _regionRepository.AddAysnc(regionDomainModel);
        

        // //map Domian Models TO Dto

    
          var regionDto=_mapper.Map<RegionsDTO>(regionDomainModel);

        return CreatedAtAction(nameof(GetById), new { id = regionDto.Id },regionDto);

        //Create Region Model
       

   

    }

[HttpPut]
[Route("{id:guid}")]
[ValidateModel]
public async Task <IActionResult> Edit([FromRoute]Guid id,[FromBody]UpdateRegionRequestDto updateRegionRequestDto){

    if(ModelState.IsValid){

        var regionModel = _mapper.Map<Regions>(updateRegionRequestDto);

        if (regionModel == null)
            return NotFound();

        regionModel = await _regionRepository.UpdateAysnc(id, regionModel);
        

        //Convert Region Model To Dto
   
      var  regionDto = _mapper.Map<RegionsDTO>(regionModel);

        return Ok(regionDto);
    }
        return BadRequest();

}
 
[HttpDelete]
[Route("{id:guid}")]
 public async Task <IActionResult> Delete([FromRoute]Guid id){
        var regionModel =  await _regionRepository.GetByIdAysnc(id);

        if (regionModel == null)
            return NotFound();


        await _regionRepository.Remove(regionModel);
        //map

        var regionDto = _mapper.Map<RegionsDTO>(regionModel);

        return Ok(regionDto);

 }


}