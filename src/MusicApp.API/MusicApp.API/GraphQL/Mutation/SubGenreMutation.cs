using HotChocolate;
using HotChocolate.Data;
using MusicApp.API.Data;
using MusicApp.API.GraphQL.SubGenres;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Mutation
{
    public class SubGenreMutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<CreateSubGenrePayload> CreateSubGenreAsync(CreateSubGenreInput input,
            [ScopedService] ApplicationDbContext dbContext)
        {
            var subGenre = new SubGenre
            {
                Title = input.Title,
                DateCreated = input.DateCreated,
                GenreId = input.GenreId
            };

            dbContext.SubGenres.Add(subGenre);
            await dbContext.SaveChangesAsync();

            return new CreateSubGenrePayload(subGenre);
        }
    }
}
