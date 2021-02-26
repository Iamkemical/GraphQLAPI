using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using MusicApp.API.Data;
using MusicApp.API.GraphQL.Artists;
using MusicApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Mutation
{
    [ExtendObjectType(Name = "Mutation")]
    public class ArtistMutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<CreateArtistPayload> CreateArtistAsync(CreateArtistInput input,
            [ScopedService] ApplicationDbContext dbContext)
        {
            var artist = new Artist
            {
                Name = input.Name,
                GenreId = input.GenreId,
                SubGenreId = input.SubGenreId,
                MusicId = input.MusicId
            };
            dbContext.Artists.Add(artist);
            await dbContext.SaveChangesAsync();

            return new CreateArtistPayload(artist);
        }
    }
}
