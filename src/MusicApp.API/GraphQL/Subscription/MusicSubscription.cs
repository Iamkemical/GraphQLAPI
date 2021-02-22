using HotChocolate;
using HotChocolate.Types;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Subscription
{
    [GraphQLDescription("This represents the subscription for the music resource")]
    public class MusicSubscription
    {
        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscription for real-time update on the create music mutation action")]
        public Music OnMusicCreate([EventMessage] Music music)
        {
            return music;
        }

        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscription for real-time update on the update music mutation action")]
        public Music OnMusicUpdate([EventMessage] Music music)
        {
            return music;
        }

        [Subscribe]
        [Topic]
        [GraphQLDescription("Subscription for real-time update on the delete music mutation action")]
        public string OnMusicDelete([EventMessage] string message)
        {
            return message;
        }
    }
}
