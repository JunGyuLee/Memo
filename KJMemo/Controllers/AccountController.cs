using KJMemo.Extensions.TempData;
using KJMemo.Models;
using KJMemo.Models.DAO;
using KJMemo.Models.DTO;
using KJMemo.Models.DTO.Account;
using KJMemo.Models.Enums;
using KJMemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KJMemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly KJContext mDbContext;
        private readonly IEmailSender mEmailSender;

        public AccountController(ILogger<AccountController> logger, KJContext dbContext, IEmailSender emailSender)
        {
            _logger = logger;
            mDbContext = dbContext;
            mEmailSender = emailSender;
        }


        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            TempData.Put(ETempData.MESSAGE, new PageMessageViewModel("환영합니다.", "안녕하세요 아무개님.", EMessageType.SUCCESS));
            return Redirect("/Home/Index");
        }


        public IActionResult Regist()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistAsync(RegistViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Member member = new Member(new System.Guid(), vm.Name, vm.Email, vm.Password, true);

            await mDbContext.Members.AddAsync(member);
            await mDbContext.SaveChangesAsync();

            List<string> emails = new List<string>();
            emails.Add(vm.Email);

            await mEmailSender.SendEmailAsync(emails, "회원 인증", "회원가입을 해주셔서 감사합니다.");

            TempData.Put(ETempData.MESSAGE, new PageMessageViewModel("회원가입 완료", "로그인 해주세요.", EMessageType.SUCCESS));


            return Redirect("Login");

        }

        public IActionResult VerifyEmail(string email)
        {
            if (mDbContext.Members.Where(m => m.Email == email).Any())
            {
                return Json($"Email {email} is already in use.");
            }

            return Json(true);
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
        public async Task<IActionResult> PasswordResetAsync(PasswordResetViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            List<string> emails = new List<string>();
            emails.Add(vm.Email);

            Member member = await mDbContext.Members.FirstOrDefaultAsync(m => m.Email == vm.Email);

            await mEmailSender.SendEmailAsync(emails, "비밀번호를 재설정해주세요.", $"<a href='https://localhost:44398/Account/PasswordSetting?email={member.Email}'>비밀번호 재설정</a>");

            return RedirectToAction("Login");
        }

        public IActionResult PasswordSettingAsync([FromQuery]string email)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordSettingAsync(PasswordSettingViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Member member = await mDbContext.Members.FirstOrDefaultAsync(m => m.Email == viewModel.Email);

            member.Password = viewModel.Password;
            await mDbContext.SaveChangesAsync();

            return RedirectToAction("Login");
        }
    }
}