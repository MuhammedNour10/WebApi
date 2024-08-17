using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Domain;
using WebApi.Models.DTO;
using WebApi.Repository.IRepository;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageRepository _imageRepository;

    public ImageController(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDto imageUpload)
    {
        // Validate the image upload request
        imageValidation(imageUpload);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Convert ImageUploadRequestDto to Image model
        var imageModel = new Image()
        {
            File = imageUpload.File,
            FileName = imageUpload.FileName,
            FileDescription = imageUpload.Description,
            FileExtension = Path.GetExtension(imageUpload.File.FileName),
            FileSizeInByte = imageUpload.File.Length
        };

        // Save the image using the repository
        var uploadedImage = await _imageRepository.Upload(imageModel);

        if (uploadedImage == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image.");
        }

        return Ok(uploadedImage);
    }

    private void imageValidation(ImageUploadRequestDto imageUpload)
    {
        var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };

        if (!allowedExtensions.Contains(Path.GetExtension(imageUpload.File.FileName)))
        {
            ModelState.AddModelError("file", "Unsupported file extension");
        }

        if (imageUpload.File.Length > 10485760)
        {
            ModelState.AddModelError("file", "File size exceeds 10MB");
        }
    }
}
