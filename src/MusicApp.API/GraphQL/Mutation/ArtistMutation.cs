﻿using HotChocolate;
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
        [GraphQLDescription("This represents the action for creating artist")]
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
        [GraphQLDescription("This represents the action for updating artist")]
        public async Task<UpdateArtistPayload> UpdateArtistAsync(UpdateArtistInput input,
            [ScopedService] ApplicationDbContext dbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var artistFromDb = dbContext.Artists.FirstOrDefault(a => a.Id == input.Id);

            artistFromDb.Name = input.Name;

            dbContext.Artists.Update(artistFromDb);
            await dbContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(ArtistSubscription.OnArtistUpdate),
                artistFromDb, cancellationToken);

            return new UpdateArtistPayload(artistFromDb);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [GraphQLDescription("This represents the action for deleting artist")]
        public async Task<DeleteArtistPayload> DeleteArtistAsync(DeleteArtistInput input,
            [ScopedService] ApplicationDbContext dbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var artistFromDb = dbContext.Artists.FirstOrDefault(a => a.Id == input.Id);

            dbContext.Artists.Remove(artistFromDb);
            await dbContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(ArtistSubscription.OnArtistDelete),
                "Artist successfully deleted!", cancellationToken);

            return new DeleteArtistPayload("Artist successfully deleted!");
        }
    }
}
