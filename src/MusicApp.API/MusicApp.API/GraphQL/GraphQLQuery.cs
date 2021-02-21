using HotChocolate;
using MusicApp.API.Data;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL
{
    public class GraphQLQuery
    {
        public IQueryable<Genre> GetGenres([Service] ApplicationDbContext dbContext)
        {
            return dbContext.Genres;
        }
    }
}
