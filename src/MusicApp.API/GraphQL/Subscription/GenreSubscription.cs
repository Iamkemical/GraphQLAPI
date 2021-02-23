using HotChocolate;
using HotChocolate.Types;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Subscription
{
    [ExtendObjectType(Name = "Subscription")]
    [GraphQLDescription("This represents the subscription for the genre resource")]
    public class GenreSubscription
    {
        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscription for real-time update on the create genre mutation action")]
        public Genre OnGenreCreate([EventMessage] Genre genre)
        {
            return genre;
        }

        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscription for real-time update on the update genre mutation action")]
        public Genre OnGenreUpdate([EventMessage] Genre genre)
        {
            return genre;
        }

        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscription for real-time update on the delete genre mutation action")]
        public string OnGenreDelete([EventMessage] string message)
        {
            return message;
        }
    }
}
