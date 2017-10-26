using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UserController : Controller
    {
        [Route("api/User/IsRegistered")]
        [HttpPost]
        [ResponseCache(Duration = 120)]
        public async Task<bool> Index([FromBody]UserBotChannel channel)
        {
            return false;
        }
    }
}