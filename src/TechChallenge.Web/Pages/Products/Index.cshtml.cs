using Microsoft.AspNetCore.Mvc.RazorPages;
using TechChallenge.Application.Queries;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Web.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductQueries _productQueries;
        private readonly ILogger<IndexModel> _logger;

        public List<Product> Products { get; private set; }

        public IndexModel(
            IProductQueries productQueries,
            ILogger<IndexModel> logger)
        {
            _productQueries = productQueries;
            _logger = logger;
        }

        public async Task OnGet()
        {
            Products = await _productQueries.GetAllAsync();
        }


    }
}
