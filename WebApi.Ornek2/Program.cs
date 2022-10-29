using Microsoft.EntityFrameworkCore;
using WebApi.Ornek2.Entites;

namespace WebApi.Ornek2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<WebApiDBContext>(conf =>
            {
                conf.UseSqlServer(builder.Configuration.GetConnectionString("DbYolu"));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "test",
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:5131");
                                  });
            });

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();

            // localhost farklý portaldan request olduðu için webapi cross origin requestleri engeller. bunu localde açýyoruz..
            app.UseCors(conf =>
            {
                conf.AllowAnyOrigin();
                conf.AllowAnyMethod();
                conf.AllowAnyHeader();
            });

            app.Run();
        }
    }
}