using Microsoft.AspNetCore.Mvc;

namespace Umbraco9.Backoffice.Controllers
{
    [Route("/")]
    public class BackofficeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectPermanent("/umbraco");
        }
    }
}
