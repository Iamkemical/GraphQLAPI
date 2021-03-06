using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicApp.API.Data;
using MusicApp.API.GraphQL;
using MusicApp.API.GraphQL.Genres;
using MusicApp.API.GraphQL.Musics;
using MusicApp.API.GraphQL.Mutation;
using MusicApp.API.GraphQL.SubGenres;
using MusicApp.API.GraphQL.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MusicApp.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services
                .AddGraphQLServer()
                .AddQueryType<GraphQLQuery>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<GenreMutation>()
                    .AddTypeExtension<SubGenreMutation>()
                    .AddTypeExtension<MusicMutation>()
                    .AddTypeExtension<ArtistMutation>()
                .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddTypeExtension<GenreSubscription>()
                    .AddTypeExtension<SubGenreSubscription>()
                    .AddTypeExtension<MusicSubscription>()
                    .AddTypeExtension<ArtistSubscription>()
                .AddFiltering()
                .AddSorting()
                .AddType<GenreType>()
                .AddType<SubGenreType>()
                .AddType<MusicType>()
                .AddProjections()
                .AddInMemorySubscriptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager"
            });
        }
    }
}
