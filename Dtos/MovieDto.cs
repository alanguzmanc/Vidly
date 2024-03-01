﻿using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]       
        [MaxLength(255)]
        public string Name { get; set; }     

        [Required]
        public int GenreId { get; set; }
        public DateTime DateAdded { get; set; }        
        public DateTime ReleaseDate { get; set; }
        
        [Range(1, 30)]
        public byte NumberInStock { get; set; }
    }
}
