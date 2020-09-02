
using KJMemo.Extensions.TempData;
using KJMemo.Models;
using KJMemo.Models.DTO;
using KJMemo.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KJMemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }


        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel vm){

            if(!ModelState.IsValid){
                return View(vm);
            }


            TempData.Put(ETempData.MESSAGE, new PageMessageViewModel("환영합니다.","안녕하세요 아무개님.",EMessageType.SUCCESS));
            return Redirect("/Home/Index");
        }


        public IActionResult Regist()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Regist(RegistViewModel vm){

            if(!ModelState.IsValid){
                return View(vm);
            }
            
            TempData.Put(ETempData.MESSAGE, new PageMessageViewModel("회원가입 완료","로그인 해주세요.",EMessageType.SUCCESS));


            return Redirect("Login");

        }

        public IActionResult ConfirmEmail()
        {

            return View();
        }


        public IActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PasswordReset(PasswordResetViewModel vm)
        { 

            if(!ModelState.IsValid){
                return View(vm);
            }

            return RedirectToAction("Login");
        }
    }
}