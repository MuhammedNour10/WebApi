using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApi.MiddleWares;


public class ExeptionHandleMiddleWare{
    private readonly ILogger<ExeptionHandleMiddleWare> logger;
    private readonly RequestDelegate request;
  public ExeptionHandleMiddleWare(ILogger<ExeptionHandleMiddleWare> logger,
   RequestDelegate request
  )
  {
        this.request = request;
        this.logger = logger;
    
  }


    public async Task InvokeAsync(HttpContext httpContext)
{
    try
    {
        // Call the next middleware in the pipeline
        await request(httpContext);
    }
    catch (Exception ex)
    {
        // Create a unique error ID
        var errorId = Guid.NewGuid();
        
        // Log the exception with the error ID
        logger.LogError(ex, $"{errorId} : {ex.Message}");
        
        // Prepare a custom error response
        var errorResponse = new 
        {
            ErrorId = errorId,
            Message = "An unexpected error occurred. Please try again later."
        };
        
        // Set the response status code and content type
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";
        
        // Write the error response as JSON
        await httpContext.Response.WriteAsJsonAsync(errorResponse);
    }
}
}