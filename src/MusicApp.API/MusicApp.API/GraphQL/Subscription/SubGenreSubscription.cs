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
    }
}
