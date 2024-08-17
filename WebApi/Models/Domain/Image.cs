using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Domain;


public class Image{

 public Guid Id{ get; set; }
[NotMapped]
 public required IFormFile File{ get; set; }

 public string FileName { get; set; } = "";

public string? FileDescription{ get; set; }

    public string FileExtension { get; set; } = "";

    public string FilePath { get; set; } = "";

    public long FileSizeInByte{ get; set; }
    




}