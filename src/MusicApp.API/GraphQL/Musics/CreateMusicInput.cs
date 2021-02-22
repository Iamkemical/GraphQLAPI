using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MusicApp.API.Models.Music;

namespace MusicApp.API.GraphQL.Musics
{
    public record CreateMusicInput(string Name, DateTime DateCreated, 
         AudienceType Audience, RatingType Rating, byte[] Picture,
         int GenreId, int SubGenreId);
}
