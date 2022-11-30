using MagicEsatate_Web.Models;
using MagicEsatate_Web.Models.Dto;
using MagicEstate_Web.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace MagicEstate_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO obj = new();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestDTO obj)
        {
           
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registe(RegistrationRequestDTO obj)
        {
            APIResponse result =  await _authService.ReegisterAsync<APIResponse>(obj);
            if(result !=null && result.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {

            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
