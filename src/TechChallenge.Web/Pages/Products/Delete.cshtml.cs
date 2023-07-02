using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechChallenge.Application.Queries;
using TechChallenge.Application.UseCases.ClearImages;
using TechChallenge.Application.UseCases.DeleteProduct;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Web.Pages.Products
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IProductQueries _productQueries;
        private readonly IDeleteProductUseCase _deleteProductUseCase;
        private readonly IClearImagesUseCase _clearImagesUseCase;
        private readonly ILogger<IndexModel> _logger;

        public Product Product { get; set; }

        public DeleteModel(
            ILogger<IndexModel> logger,
            IProductQueries productQueries,
            IDeleteProductUseCase deleteProductUseCase,
            IClearImagesUseCase clearImagesUseCase)
        {
            _logger = logger;
            _productQueries = productQueries;
            _deleteProductUseCase = deleteProductUseCase;
            _clearImagesUseCase = clearImagesUseCase;
        }

        public async Task OnGet(Guid? id)
        {
            Product = await _productQueries.GetByIdAsync((Guid)id);
        }

        public async Task<IActionResult> OnPost()
        {
            await _clearImagesUseCase.ExecuteAsync(Product.Id);
            await _deleteProductUseCase.ExecuteAsync(Product.Id);
            return RedirectToPage("Index");
        }
    }
}
