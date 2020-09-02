using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KJMemo.Controllers
{

    public class TaskController : Controller
    {

        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }


        public IActionResult Tasks(){

            return View();
        }
    }
}