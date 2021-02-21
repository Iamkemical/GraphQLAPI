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
        [GraphQLDescription("This represents the action for creating genres")]
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

        [UseDbContext(typeof(ApplicationDbContext))]
        [GraphQLDescription("This represents the action for updating genres")]
        public async Task<UpdateGenrePayload> UpdateGenreAsync(UpdateGenreInput input, 
            [ScopedService] ApplicationDbContext dbContext)
        {
            var genreFromDb = dbContext.Genres.FirstOrDefault(g => g.Id == input.Id);

            genreFromDb.Title = input.Title;
            genreFromDb.DateCreated = input.DateCreated;

            dbContext.Genres.Update(genreFromDb);
            await dbContext.SaveChangesAsync();

            return new UpdateGenrePayload(genreFromDb);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [GraphQLDescription("This represents the action for deleting genres")]
        public async Task<DeleteGenrePayload> DeleteGenreAsync(DeleteGenreInput input, 
            [ScopedService] ApplicationDbContext dbContext)
        {
            var genreFromDb = dbContext.Genres.FirstOrDefault(g => g.Id == input.Id);

            dbContext.Genres.Remove(genreFromDb);
            await dbContext.SaveChangesAsync();

            return new DeleteGenrePayload("Genre successfully deleted!");
        }
    }
}
