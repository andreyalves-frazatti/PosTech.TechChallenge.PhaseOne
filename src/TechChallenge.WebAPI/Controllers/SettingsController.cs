using System;
using Microsoft.AspNetCore.Mvc;

namespace TechChallenge.WebAPI.Controllers
{
    public class SettingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SettingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetSettings()
        {
            var azureConnectionString = _configuration.GetConnectionString("AzureBlobStorage");
            var azureSqlServerConnectionString = _configuration.GetConnectionString("AzureSqlServer");

            return Ok(new
            {
                azureConnectionString, azureSqlServerConnectionString
            });
        }
    }
}

