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
    public class ArtistSubscription
    {
        [Subscribe]
        [Topic]
        public Artist OnArtistCreate([EventMessage] Artist artist)
        {
            return artist;
        }
    }
}
