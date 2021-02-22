using HotChocolate;
using HotChocolate.Types;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Subscription
{
    public class MusicSubscription
    {
        [Subscribe]
        [Topic]
        public Music OnMusicCreate([EventMessage] Music music)
        {
            return music;
        }
    }
}
