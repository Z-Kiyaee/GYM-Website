using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        #region Ctor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Register

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.RegisterUser(userDTO))
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["ErrorMessage"] = "You have already had an account";
            return View();
        }

        #endregion

        #region Login

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByMobile(userDTO.Mobile);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                       new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                       new (ClaimTypes.MobilePhone, user.Mobile),
                       new (ClaimTypes.Name, user.Name),
                    };

                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(claimIdentity);

                    var authProps = new AuthenticationProperties();
                    //authProps.IsPersistent = model.RememberMe;

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["ErrorMessage"] = "No user was found!";
            return View();
        }
        #endregion

        #region Logout

        #endregion
    }
}
