using HotChocolate;
using HotChocolate.Types;
using MusicApp.API.Data;
using MusicApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.Musics
{
    public class MusicType : ObjectType<Music>
    {
        protected override void Configure(IObjectTypeDescriptor<Music> descriptor)
        {
            descriptor.Description("This represents all the music songs");

            descriptor.Field(m => m.Id)
                .Description("This represents the id of the music");

            descriptor.Field(m => m.Name)
                .Description("This represents the title of the music");

            descriptor.Field(m => m.DateCreated)
                .Description("This represents the day the music was created");

            descriptor.Field(m => m.Rating)
                .Description("This represents the different music ratings");

            descriptor.Field(m => m.Audience)
                .Description("This represents the different audience categories");

            descriptor.Field(m => m.GenreId)
                .Description("This is the foreign key for the genre table");

            descriptor.Field(m => m.SubGenreId)
                .Description("This is the foreign key for the subgenre table");

            descriptor.Field(m => m.GenreId)
                .ResolveWith<Resolvers>(m => m.GetGenre)
                .UseDbContext<ApplicationDbContext>()
                .Description("This represents the genre in the music");

            descriptor.Field(m => m.SubGenreId)
                .ResolveWith<Resolvers>()
                .UseDbContext<ApplicationDbContext>()
                .Description("This represents the subgenre in music");
        }

        private class Resolvers
        {
            public IQueryable<Genre> GetGenre(Music music,
                [ScopedService] ApplicationDbContext dbContext)
            {
                return dbContext.Genres.Where(m => m.Id == music.GenreId);
            }

            public IQueryable<SubGenre> GetSubGenre(Music music,
                [ScopedService] ApplicationDbContext dbContext)
            {
                return dbContext.SubGenres.Where(m => m.Id == music.SubGenreId);
            }
        }
    }
}
