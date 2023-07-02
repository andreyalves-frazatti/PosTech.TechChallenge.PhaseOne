using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechChallenge.Application;
using TechChallenge.Application.Queries;
using TechChallenge.Application.UseCases.CreateImage;
using TechChallenge.Application.UseCases.DeleteImage;
using TechChallenge.Application.UseCases.EditProduct;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Web.Pages.Products
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IProductQueries _productQueries;
        private readonly ICreateImageUseCase _createImageUseCase;
        private readonly IDeleteImageUseCase _deleteImageUseCase;
        private readonly IEditProductUseCase _editProductUseCase;
        private readonly ILogger<IndexModel> _logger;

        public Product Product { get; set; }

        public EditModel(
            ILogger<IndexModel> logger,
            IProductQueries productQueries,
            IDeleteImageUseCase deleteImageUseCase,
            ICreateImageUseCase createImageUseCase,
            IEditProductUseCase editProductUseCase)
        {
            _logger = logger;
            _productQueries = productQueries;
            _deleteImageUseCase = deleteImageUseCase;
            _createImageUseCase = createImageUseCase;
            _editProductUseCase = editProductUseCase;
        }

        public async Task OnGet(Guid? id)
        {
            Product = await _productQueries.GetByIdAsync((Guid)id);
        }

        public async Task<IActionResult> OnPost(List<IFormFile> files)
        {
            await _editProductUseCase.ExecuteAsync(Product);

            foreach (var file in files)
            {
                using var stream = file.OpenReadStream();
                CreateImageUseCaseInput imageInput = new()
                {
                    Stream = stream,
                    Extension = "",
                    ProductId = Product.Id
                };
                await _createImageUseCase.ExecuteAsync(imageInput);
            }

            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostRemove(Guid imageId)
        {
            await _deleteImageUseCase.ExecuteAsync(imageId);
            return RedirectToPage(new { id = Product.Id });
        }
    }
}
