using Microsoft.AspNetCore.Mvc;
using NZwalk.Web.Models.Dto;

namespace NZwalk.Web.Controllers;

public class RegionController:Controller{

    private readonly IHttpClientFactory httpClient;
public RegionController(IHttpClientFactory httpClient)
{

        this.httpClient = httpClient;
}


public async Task<IActionResult> Index(){
        var response = new List<regionDto>();

    try{

        var client = httpClient.CreateClient();
            var urlApi = "https://localhost:7270/api/Regions";

      var httpResponseMessage= await client.GetAsync(urlApi);
        httpResponseMessage.EnsureSuccessStatusCode();

      response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<regionDto>>());
    }catch(Exception ex){


    }

        return View(response);
}




}