using System;
using Microsoft.AspNetCore.Mvc;
using SecurityTokenService.Models.BotAccount;

namespace SecurityTokenService.Controllers
{
    public class BotAccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(BotRegisterViewModel registerViewModel)
        {
            return View();
        }
    }
}