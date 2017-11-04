using System;
using System.Threading.Tasks;
using Bot.Api.Gateway;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecurityTokenService.Models;
using SecurityTokenService.Models.AccountViewModels;

namespace SecurityTokenService.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class BotAccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApiSettings apiSettings;

        public BotAccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApiSettings apiSettings)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.apiSettings = apiSettings;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(
            string botChannelType,
            string botChannelUserId)
        {
            ViewData["BotChannelType"] = botChannelType;
            ViewData["BotChannelUserId"] = botChannelUserId;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(BotRegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    string confirmationCode = GetConfirmationCode(
                    user.Id,
                    model.BotChannelType,
                    model.BotChannelUserId);
                    return RedirectToAction(
                        nameof(ConfirmationCode),
                        "BotAccount",
                        new { confirmationCode });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public IActionResult ConfirmationCode(string confirmationCode)
        {
            return View("ConfirmationCode", confirmationCode);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private string GetConfirmationCode(
            long userId,
            string channelType,
            string channelUserId)
        {
            using (var client = new ApiClient(apiSettings))
            {
                return client.GetConfirmationCode(
                    userId,
                    channelType,
                    channelUserId);
            }
        }
    }
}