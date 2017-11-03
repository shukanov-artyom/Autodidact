using System;
using System.ComponentModel.DataAnnotations;

namespace SecurityTokenService.Models.AccountViewModels
{
    public class BotRegisterViewModel : RegisterViewModel
    {
        [Required]
        public string BotChannelType { get; set; }

        [Required]
        public string BotChannelUserId { get; set; }
    }
}
