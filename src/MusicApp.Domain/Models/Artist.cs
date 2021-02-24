using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicApp.Domain.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        [Required]
        public int SubGenreId { get; set; }

        [ForeignKey("SubGenreId")]
        public virtual SubGenre SubGenre { get; set; }

        [Required]
        public int MusicId { get; set; }

        [ForeignKey("MusicId")]
        public virtual Music Music { get; set; }
    }
}
