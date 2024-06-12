using AcodeX_Web_Sitesi.Models;
using DataAccsess.Concrate;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace AcodeX_Web_Sitesi.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        public AccountController(SignInManager<User> signInManager, IEmailSender emailSender, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(p.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, p.Password, true, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Hatalı parola.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Sisteme kayıtlı olmayan e-posta adresi.");
                    return View();
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                // Kullanıcı yoksa veya e-postası onaylanmamışsa, gizlilik nedeniyle yine de başarılı bir sonuç göster
                return RedirectToAction("ForgotPasswordConfirmation");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("ResetPassword", "LoginUser", new { token, email = user.Email }, protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(
                model.Email,
                "Parola Sıfırlama Talebi",
                $"Parolanızı sıfırlamak için lütfen <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>buraya tıklayın</a>.");

            return RedirectToAction("ForgotPasswordConfirmation");
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string email)
        {
            var model = new ResetPasswordViewModel { Email = email };
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                return RedirectToAction("ForgotPasswordConfirmation");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("ResetPassword", "LoginUser", new { token, email = user.Email }, protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(
                model.Email,
                "Parola Sıfırlama Talebi",
                $"Parolanızı sıfırlamak için lütfen <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>buraya tıklayın</a>." +
                $"" +
                $"" +
                $"AcodeX Academy");

            return RedirectToAction("ForgotPasswordConfirmation");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = p.Email,
                    UserName = p.UserName,
                    NameSurname = p.NameSurname
                };

                var result = await _userManager.CreateAsync(user, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

