using HotChocolate;
using HotChocolate.Types;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Subscription
{
    public class SubGenreSubscription
    {
       [Subscribe]
       [Topic]
       public SubGenre OnSubGenreCreate([EventMessage] SubGenre subGenre)
       {
            return subGenre;
       }

        [Subscribe]
        [Topic]
        public SubGenre OnSubGenreUpdate([EventMessage] SubGenre subGenre)
        {
            return subGenre;
        }

        [Subscribe]
        [Topic]
        public string OnSubGenreDelete([EventMessage] string message)
        {
            return message;
        }
    }
}
