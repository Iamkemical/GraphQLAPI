using HotChocolate;
using HotChocolate.Data;
using MusicApp.Data.DatabaseContext;
using MusicApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<GenreModel> GetModels([ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.Genres;
        }
    }
}
