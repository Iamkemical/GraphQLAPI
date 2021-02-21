using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Genres
{
    public record UpdateGenreInput(int Id, string Title, DateTime DateCreated);
}
