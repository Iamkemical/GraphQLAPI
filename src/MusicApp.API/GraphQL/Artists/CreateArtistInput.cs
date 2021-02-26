using MusicApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Artists
{
    public record CreateArtistInput(string Name, int GenreId, int SubGenreId, int MusicId);
}
