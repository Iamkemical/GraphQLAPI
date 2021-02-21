using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.Models
{
    public class Music
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public enum AudienceType { U, PG, TWELVEA, FIFTEEN, EIGHTEEN }

        public AudienceType Audience { get; set; }

        public enum RatingType { Poor, Average, BlockBuster }

        public RatingType Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        [Required]
        public int SubGenreId { get; set; }

        [ForeignKey("SubGenreId")]
        public virtual SubGenre SubGenre { get; set; }
    }
}
