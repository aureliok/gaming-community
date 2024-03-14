﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    public class UserProfile
    {
        public int UserId { get; }
        public string? Bio { get; set; }
        public string? AvatarId { get; set; }
        public string? GamingPlatformLink { get; set; }
    }
}
