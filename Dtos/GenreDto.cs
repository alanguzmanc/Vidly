﻿using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class GenreDto
    {
        public int Id { get; set; }   
        public string Name { get; set; } = string.Empty;
    }
}