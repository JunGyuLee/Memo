
using KJMemo.Extensions.TempData;
using KJMemo.Models;
using KJMemo.Models.DAO;
using KJMemo.Models.DTO;
using KJMemo.Models.DTO.Account;
using KJMemo.Models.Enums;
using KJMemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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

            Member member = new Member();
            member.MemberID = new System.Guid();
            member.Name = vm.Name;
            member.Email = vm.Email;
            member.Password = vm.Password;
            member.IsValid = true;

            mDbContext.Members.Add(member);
            mDbContext.SaveChanges();

            List<string> emails = new List<string>();
            emails.Add(vm.Email);

            mEmailSender.SendEmailAsync(emails, "회원 인증", "회원가입을 해주셔서 감사합니다.");

            TempData.Put(ETempData.MESSAGE, new PageMessageViewModel("회원가입 완료","로그인 해주세요.",EMessageType.SUCCESS));


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
        public IActionResult PasswordReset(PasswordResetViewModel vm)
        { 

            if(!ModelState.IsValid){
                return View(vm);
            }

            List<string> emails = new List<string>();
            emails.Add(vm.Email);

            Member member = mDbContext.Members.Where(m => m.Email == vm.Email).FirstOrDefault();
           
            mEmailSender.SendEmailAsync(emails, "비밀번호를 재설정해주세요.", $"<a>https://localhost:44398/Account/PasswordSetting?email={member.Email}<a>");

            return RedirectToAction("Login");
        }

        public IActionResult PasswordSetting([FromQuery]string email)
        {
            return View();
        }

        [HttpPost]
        public IActionResult PasswordSetting(PasswordSettingViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Member member = mDbContext.Members.Where(m => m.Email == viewModel.Email).FirstOrDefault();

            member.Password = viewModel.Password;
            mDbContext.SaveChangesAsync();

            return RedirectToAction("Login");
        }
    }
}