﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    public class UserLevel
    {
        public int LevelId { get; }
        public string Level { get; set; }
    }
}
