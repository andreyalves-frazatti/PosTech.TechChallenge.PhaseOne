using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Web.Models;

public class CreateImageViewModel
{
    [Required]
    public required Guid ProductId { get; init; }

    [Required]
    public required IFormFile File { get; init; }
}
