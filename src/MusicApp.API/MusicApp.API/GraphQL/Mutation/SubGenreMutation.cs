using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using MusicApp.API.Data;
using MusicApp.API.GraphQL.SubGenres;
using MusicApp.API.GraphQL.Subscription;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Mutation
{
    public class SubGenreMutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        [GraphQLDescription("This represents the action for creating subgenre")]
        public async Task<CreateSubGenrePayload> CreateSubGenreAsync(CreateSubGenreInput input,
            [ScopedService] ApplicationDbContext dbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var subGenre = new SubGenre
            {
                Title = input.Title,
                DateCreated = input.DateCreated,
                GenreId = input.GenreId
            };

            dbContext.SubGenres.Add(subGenre);
            await dbContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(SubGenreSubscription.OnSubGenreCreate),
                subGenre, cancellationToken);

            return new CreateSubGenrePayload(subGenre);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [GraphQLDescription("This represents the action for updating subgenre")]
        public async Task<UpdateSubGenrePayload> UpdateSubGenreAsync(UpdateSubGenreInput input, 
            [ScopedService] ApplicationDbContext dbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var subGenreFromDb = dbContext.SubGenres.FirstOrDefault(s => s.Id == input.Id);

            subGenreFromDb.Title = input.Title;
            subGenreFromDb.DateCreated = input.DateCreated;

            dbContext.SubGenres.Update(subGenreFromDb);
            await dbContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(SubGenreSubscription.OnSubGenreUpdate),
                subGenreFromDb, cancellationToken);

            return new UpdateSubGenrePayload(subGenreFromDb);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [GraphQLDescription("This represents the action for deleting subgenre")]
        public async Task<DeleteSubGenrePayload> DeleteSubGenreAsync(DeleteSubGenreInput input,
            [ScopedService] ApplicationDbContext dbContext)
        {
            var subGenreFromDb = dbContext.SubGenres.FirstOrDefault(s => s.Id == input.Id);

            dbContext.SubGenres.Remove(subGenreFromDb);
            await dbContext.SaveChangesAsync();

            return new DeleteSubGenrePayload("SubGenre successfully deleted!");
        }
    }
}
