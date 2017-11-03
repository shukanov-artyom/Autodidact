using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SecurityTokenService.Controllers
{
    public class ControllerBase : Controller
    {
        protected long UserId
        {
            get
            {
                string sub = User.Claims.First(c => c.Type == "sub").Value;
                return Int32.Parse(sub);
            }
        }
    }
}
