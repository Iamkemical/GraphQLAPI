using HotChocolate;
using HotChocolate.Types;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Subscription
{
    public class GenreSubscription
    {
        [Subscribe]
        [Topic]
        public Genre OnGenreCreate([EventMessage] Genre genre)
        {
            return genre;
        }

        [Subscribe]
        [Topic]
        public Genre OnGenreUpdate([EventMessage] Genre genre)
        {
            return genre;
        }
    }
}
