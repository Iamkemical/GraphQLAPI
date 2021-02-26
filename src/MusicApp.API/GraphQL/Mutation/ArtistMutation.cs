using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using MusicApp.API.Data;
using MusicApp.API.GraphQL.Artists;
using MusicApp.API.GraphQL.Subscription;
using MusicApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Mutation
{
    [ExtendObjectType(Name = "Mutation")]
    public class ArtistMutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<CreateArtistPayload> CreateArtistAsync(CreateArtistInput input,
            [ScopedService] ApplicationDbContext dbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var artist = new Artist
            {
                Name = input.Name,
                GenreId = input.GenreId,
                SubGenreId = input.SubGenreId,
                MusicId = input.MusicId
            };
            dbContext.Artists.Add(artist);
            await dbContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(ArtistSubscription.OnArtistCreate),
                artist, cancellationToken);

            return new CreateArtistPayload(artist);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<UpdateArtistPayload> UpdateArtistAsync(UpdateArtistInput input,
            [ScopedService] ApplicationDbContext dbContext)
        {
            var artistFromDb = dbContext.Artists.FirstOrDefault(a => a.Id == input.Id);

            artistFromDb.Name = input.Name;

            dbContext.Artists.Update(artistFromDb);
            await dbContext.SaveChangesAsync();

            return new UpdateArtistPayload(artistFromDb);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<DeleteArtistPayload> DeleteArtistAsync(DeleteArtistInput input,
            [ScopedService] ApplicationDbContext dbContext)
        {
            var artistFromDb = dbContext.Artists.FirstOrDefault(a => a.Id == input.Id);

            dbContext.Artists.Remove(artistFromDb);
            await dbContext.SaveChangesAsync();

            return new DeleteArtistPayload("Artist successfully deleted");
        }
    }
}
