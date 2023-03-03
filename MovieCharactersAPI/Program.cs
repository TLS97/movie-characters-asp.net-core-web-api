using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Services.CharacterServices;
using MovieCharactersAPI.Services.FranchiseServices;
using MovieCharactersAPI.Services.MovieServices;
using System.Reflection;

namespace MovieCharactersAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Set the comments path for the Swagger JSON and UI

            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<MovieCharactersDbContext>(
                opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MovieCharactersDb"))
            );

            builder.Services.AddScoped<ICharacterService, CharacterService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddTransient<IFranchiseService, FranchiseService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MovieCharacters API",
                    Description = "An ASP.NET Core Web API for managing franchises, movies and related characters.",
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            // Automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}