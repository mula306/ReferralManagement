using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReferralAPI.Data;
using ReferralAPI.Model;
using ReferralAPI.Endpoints;

namespace ReferralAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ReferralAPIContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("ReferralAPIContext") ?? throw new InvalidOperationException("Connection string 'ReferralAPIContext' not found.")));

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapPatientEndpoints();

            app.MapReferralEndpoints();

            app.MapProviderEndpoints();

            app.MapSpecialtyEndpoints();

            app.MapDynamicReferralEndpoints();

            app.Run();
        }
    }
}