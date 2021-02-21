using HotChocolate;
using HotChocolate.Data;
using MusicApp.API.Data;
using MusicApp.API.GraphQL.Musics;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Mutation
{
    public class MusicMutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<CreateMusicPayload> CreateMusicAsync(CreateMusicInput input,
            [ScopedService] ApplicationDbContext dbContext)
        {
            var music = new Music
            {
                Name = input.Name,
                DateCreated = input.DateCreated,
                Audience = input.Audience,
                Rating = input.Rating,
                Picture = input.Picture,
                GenreId = input.GenreId,
                SubGenreId = input.SubGenreId
            };

            dbContext.Musics.Add(music);
            await dbContext.SaveChangesAsync();

            return new CreateMusicPayload(music);
        }
    }
}
