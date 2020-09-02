using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KJMemo.Controllers
{

    public class ComponentController : Controller
    {

        private readonly ILogger<ComponentController> _logger;

        public ComponentController(ILogger<ComponentController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index(){

            return View();
        }
    }
}