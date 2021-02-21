using HotChocolate;
using HotChocolate.Types;
using MusicApp.API.Data;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.SubGenres
{
    public class SubGenreType : ObjectType<SubGenre>
    {
        protected override void Configure(IObjectTypeDescriptor<SubGenre> descriptor)
        {
            descriptor.Description("This represents all the music subgenre");

            descriptor.Field(s => s.Id)
                .Description("This represents the id of the subgenre");

            descriptor.Field(s => s.Title)
                .Description("This represents the title of the subgenre");

            descriptor.Field(s => s.DateCreated)
                .Description("This represents the date the subgenre was created");

            descriptor.Field(s => s.GenreId)
                .Description("This represents the foreign key id in the subgenre");

            descriptor.Field(s => s.Genre)
                .ResolveWith<Resolvers>(s => s.GetGenres(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("This represents all the genre in the subgenre");
        }

        private class Resolvers
        {
            public IQueryable<SubGenre> GetGenres(Genre genre,
                [ScopedService] ApplicationDbContext dbContext)
            {
                return dbContext.SubGenres.Where(s => s.GenreId == genre.Id);
            }
        }
    }
}
