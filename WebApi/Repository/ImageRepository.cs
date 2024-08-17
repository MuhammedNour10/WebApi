using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApi.Models.Domain;
using WebApi.Repository.IRepository;
using WebApi.Data;

namespace WebApi.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Image> Upload(Image image)
        {
            //1- Ensure the image directory exists
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "images");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Create a unique file name
            var fileName = $"{Guid.NewGuid()}_{image.File.FileName}";
            var filePath = Path.Combine(uploadPath, fileName);

            // Save the file to the file system
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.File.CopyToAsync(fileStream);
            }

            // Update the image object with the file path
            image.FilePath = filePath;
            

            // Save the image metadata to the database
            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return image;
        }
    }
}
