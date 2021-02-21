using HotChocolate;
using HotChocolate.Data;
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
        [UseDbContext(typeof(ApplicationDbContext))]
        [UseFiltering]
        [UseSorting]
        [UseProjection]
        public IQueryable<Genre> GetGenres([ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.Genres;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [UseFiltering]
        [UseSorting]
        [UseProjection]
        public IQueryable<SubGenre> GetSubGenres([ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.SubGenres;
        }
    }
}
