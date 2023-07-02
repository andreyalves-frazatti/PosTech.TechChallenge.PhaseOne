using Microsoft.AspNetCore.Mvc.RazorPages;
using TechChallenge.Application.Queries;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}