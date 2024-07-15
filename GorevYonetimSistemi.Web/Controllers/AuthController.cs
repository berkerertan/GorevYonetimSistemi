using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GorevYonetimSistemi.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            var accessToken = await _authService.Register(registerDto);

            if (accessToken == null)
            {
                // Handle registration failure
                ModelState.AddModelError("", "Kayıt Başarısız");
                return View(registerDto);
            }

            return RedirectToAction("Login", "Auth");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }

            var accessToken = await _authService.Login(loginDto);

            if (accessToken == null)
            {
                ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                return View();
            }

            // Store token in HTTP-only cookie
            Response.Cookies.Append("token", accessToken.Token, new CookieOptions
            {
                HttpOnly = true
            });

            // Redirect to Tasks/Index
            return RedirectToAction("Index", "Tasks");
        }
    }
}
