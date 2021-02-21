using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.Models
{
    public class SubGenre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
    }
}
