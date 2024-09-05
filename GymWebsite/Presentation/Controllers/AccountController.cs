using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        #endregion

        #region Logout

        #endregion
    }
}
