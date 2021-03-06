﻿using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using MusicApp.API.Data;
using MusicApp.API.GraphQL.Musics;
using MusicApp.API.GraphQL.Subscription;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Mutation
{
    [ExtendObjectType(Name = "Mutation")]
    public class MusicMutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        [GraphQLDescription("This represents the action for creating music")]
        public async Task<CreateMusicPayload> CreateMusicAsync(CreateMusicInput input,
            [ScopedService] ApplicationDbContext dbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
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
            await dbContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(MusicSubscription.OnMusicCreate),
                music, cancellationToken);

            return new CreateMusicPayload(music);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [GraphQLDescription("This represents the action for updating music")]
        public async Task<UpdateMusicPayload> UpdateMusicAsync(UpdateMusicInput input,
            [ScopedService] ApplicationDbContext dbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var musicFromDb = dbContext.Musics.FirstOrDefault(m => m.Id == input.Id);

            musicFromDb.Name = input.Name;
            musicFromDb.DateCreated = input.DateCreated;
            musicFromDb.Audience = input.Audience;
            musicFromDb.Rating = input.Rating;
            musicFromDb.Picture = input.Picture;

            dbContext.Musics.Update(musicFromDb);
            await dbContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(MusicSubscription.OnMusicUpdate),
                musicFromDb, cancellationToken);

            return new UpdateMusicPayload(musicFromDb);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [GraphQLDescription("This represents the action for deleting music")]
        public async Task<DeleteMusicPayload> DeleteMusicAsync(DeleteMusicInput input,
            [ScopedService] ApplicationDbContext dbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var musicFromDb = dbContext.Musics.FirstOrDefault(m => m.Id == input.Id);

            dbContext.Musics.Remove(musicFromDb);
            await dbContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(MusicSubscription.OnMusicDelete),
                "Music successfully deleted!", cancellationToken);

            return new DeleteMusicPayload("Music successfully deleted!");
        }
    }
}
