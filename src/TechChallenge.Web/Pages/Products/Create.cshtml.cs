using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TechChallenge.Application;
using TechChallenge.Application.UseCases.CreateImage;
using TechChallenge.Application.UseCases.CreateProduct;

namespace TechChallenge.Web.Pages.Products
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ICreateProductUseCase _createProductUseCase;
        private readonly ICreateImageUseCase _createImageUseCase;

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public CreateModel(
            ICreateProductUseCase createProductUseCase,
            ICreateImageUseCase createImageUseCase)
        {
            _createProductUseCase = createProductUseCase;
            _createImageUseCase = createImageUseCase;
        }

        public async Task<IActionResult> OnPost(List<IFormFile> files)
        {
            CreateProductUseCaseInput productInput = new()
            {
                Name = Name,
                Description = Description,
                Price = Price
            };

            var product = await _createProductUseCase.ExecuteAsync(productInput);

            if (product != null)
            {
                foreach (var file in files)
                {
                    using var stream = file.OpenReadStream();
                    CreateImageUseCaseInput imageInput = new()
                    {
                        Stream = stream,
                        Extension = "",
                        ProductId = product.Id
                    };
                    var image = await _createImageUseCase.ExecuteAsync(imageInput);
                }
            }

            return RedirectToPage("Index");
        }
    }
}
