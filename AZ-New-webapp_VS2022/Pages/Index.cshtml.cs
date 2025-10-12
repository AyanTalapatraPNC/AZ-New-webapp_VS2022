using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AZ_New_webapp_VS2022.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;
        public IndexModel(ILogger<IndexModel> logger,IConfiguration config)
        {
            _logger = logger;
            this._config = config;
        }

        public void OnGet()
        {
            ViewData["Greeting"]= _config["Greeting"];

        }
    }
}
