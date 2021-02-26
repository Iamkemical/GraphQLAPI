using HotChocolate;
using HotChocolate.Types;
using MusicApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Subscription
{
    [ExtendObjectType(Name = "Subscription")]
    [GraphQLDescription("This represents the subscription for the artist resource")]
    public class ArtistSubscription
    {
        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscription for real-time update on the create artist mutation action")]
        public Artist OnArtistCreate([EventMessage] Artist artist)
        {
            return artist;
        }

        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscription for real-time update on the update artist mutation action")]
        public Artist OnArtistUpdate([EventMessage] Artist artist)
        {
            return artist;
        }

        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscription for real-time update on the delete artist mutation action")]
        public string OnArtistDelete([EventMessage] string message)
        {
            return message;
        }
    }
}
