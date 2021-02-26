using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Artists
{
    public record UpdateArtistInput(int Id, string Name);
}
