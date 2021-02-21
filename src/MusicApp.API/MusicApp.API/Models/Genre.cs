using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<SubGenre> SubGenres { get; set; } = new List<SubGenre>();
    }
}
