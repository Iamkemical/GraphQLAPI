using HotChocolate;
using HotChocolate.Types;
using MusicApp.API.Data;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Genres
{
    public class GenreType : ObjectType<Genre>
    {
        protected override void Configure(IObjectTypeDescriptor<Genre> descriptor)
        {
            descriptor.Description("Represents all the music genres");

            descriptor.Field(g => g.Id)
                .Description("This represents the id of the genre");

            descriptor.Field(g => g.Title)
                .Description("This represents the title of the genre");

            descriptor.Field(g => g.DateCreated)
                .Description("This represents the date the genre was created");

            descriptor.Field(g => g.SubGenres)
                .ResolveWith<Resolvers>(s => s.GetSubGenres(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("This represents all the subgenre");
        }

        private class Resolvers
        {
            public IQueryable<SubGenre> GetSubGenres(SubGenre subGenre,
                [ScopedService] ApplicationDbContext dbContext)
            {
                return dbContext.SubGenres.Where(s => s.GenreId == subGenre.GenreId);
            }
        }
    }
}
