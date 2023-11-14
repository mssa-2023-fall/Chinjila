using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using TestAppConfig;

namespace WebappAppConfig.Pages
{
    public class IndexModel : PageModel
    {
        public Settings Settings { get; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IOptionsSnapshot<Settings> options, ILogger<IndexModel> logger)
        {
            Settings = options.Value;
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}