﻿using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Bot.Dialogs;
using Bot.Models;
using Domain;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot.Controllers
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class UserRegisteredAttribute : ActionFilterAttribute
    {
        public Services.IUserService UserService { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            object argument = actionContext.ActionArguments["activity"];
            if (actionContext.Request.Method == HttpMethod.Post
                && argument == null)
            {
                throw new InvalidOperationException("Activity cannot be null!");
            }
            else if (actionContext.Request.Method == HttpMethod.Post
                && argument != null)
            {
                Activity activity = (Activity)argument;
                if (activity.Type != ActivityTypes.Message)
                {
                    return; // assume we can do nothing
                }
                var message = activity as IMessageActivity;
                bool isRegistered = IsUserRegisteredAsync(message);
                if (!isRegistered)
                {
                    Conversation.SendAsync(
                        message,
                        () => new RegistrationDialog()).GetAwaiter().GetResult();
                }
            }
        }

        private bool IsUserRegisteredAsync(
            IMessageActivity activity)
        {
            ChannelUserInfo userInfo = new ChannelUserInfo(activity);
            var botChannel = new UserBotChannel
            {
                ChannelType = userInfo.ChannelId,
                ChannelUserId = userInfo.UserId
            };
            return UserService.IsUserRegistered(botChannel);
        }
    }
}