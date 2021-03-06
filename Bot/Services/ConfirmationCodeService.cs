﻿using System;
using Api.Gateway.Fx.Api.Gateway;
using Bot.Api.Gateway;

namespace Bot.Services
{
    public class ConfirmationCodeService : IConfirmationCodeService
    {
        private readonly ApiSettings apiSettings;

        public ConfirmationCodeService(ApiSettings apiSettings)
        {
            this.apiSettings = apiSettings;
        }

        public void ActivateConfirmationCode(
            string channelType,
            string channelUserId,
            Guid code)
        {
            using (var client = new ApiClient(apiSettings))
            {
                client.ActivateConfirmationCode(
                    channelType,
                    channelUserId,
                    code);
            }
        }

        public bool IsValidUsersConfirmationCode(
            string channelType,
            string channelUserId,
            Guid code)
        {
            using (var client = new ApiClient(apiSettings))
            {
                return client.IsValidUsersConfirmationCode(
                    channelType,
                    channelUserId,
                    code);
            }
        }
    }
}