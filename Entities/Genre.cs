﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    public class Genre
    {
        public int GenreId { get; }
        public string GenreName { get; set; }
    }
}
