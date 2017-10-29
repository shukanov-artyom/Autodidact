using System;
using System.Linq;
using System.Threading.Tasks;
using Api.DataModel;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UserController : Controller
    {
        private readonly ApiDatabaseContext database;

        public UserController(ApiDatabaseContext database)
        {
            this.database = database;
        }

        [Route("api/User/IsRegistered")]
        [HttpPost]
        [ResponseCache(Duration = 120)]
        public async Task<bool> Index([FromBody]UserBotChannel channel)
        {
            return database.ChannelUsers.Any(cu =>
                cu.ChannelType == channel.ChannelType &&
                cu.ChannelUserId == channel.ChannelUserId);
        }
    }
}