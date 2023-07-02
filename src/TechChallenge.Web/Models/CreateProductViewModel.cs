using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Web.Models;
public class CreateProductViewModel
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Description { get; set; }

    [Required]
    public required decimal Price { get; set; }
}
