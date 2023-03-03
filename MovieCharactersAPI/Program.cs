using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Services.CharacterServices;
using MovieCharactersAPI.Services.FranchiseServices;
using MovieCharactersAPI.Services.MovieServices;

namespace MovieCharactersAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
            builder.Services.AddSwaggerGen();

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