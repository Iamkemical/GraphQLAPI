using HotChocolate;
using HotChocolate.Data;
using MusicApp.API.Data;
using MusicApp.API.GraphQL.Genres;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Mutation
{
    public class GenreMutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<CreateGenrePayload> CreateGenreAsync(CreateGenreInput input,
            [ScopedService] ApplicationDbContext dbContext)
        {
            var genre = new Genre
            {
                Title = input.Title,
                DateCreated = input.DateCreated
            };

            dbContext.Genres.Add(genre);
            await dbContext.SaveChangesAsync();

            return new CreateGenrePayload(genre);
        }
    }
}
