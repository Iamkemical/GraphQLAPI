using HotChocolate;
using HotChocolate.Types;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Subscription
{
    [GraphQLDescription("This represents the subscription for the subgenre resource")]
    public class SubGenreSubscription
    {
       [Subscribe]
       [Topic]
       [GraphQLDescription("Subscription for real-time update on the create subgenre mutation action")]
        public SubGenre OnSubGenreCreate([EventMessage] SubGenre subGenre)
       {
            return subGenre;
       }

        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscription for real-time update on the update subgenre mutation action")]
        public SubGenre OnSubGenreUpdate([EventMessage] SubGenre subGenre)
        {
            return subGenre;
        }

        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscription for real-time update on the delete genre mutation action")]
        public string OnSubGenreDelete([EventMessage] string message)
        {
            return message;
        }
    }
}
