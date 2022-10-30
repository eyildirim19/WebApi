using AspNetCoreDI.Models;

namespace AspNetCoreDI
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


            // YasamSureci instance'ina ihtiyac� olan herkes instance almas� i�in instance container'a registir edilir...
            //   builder.Services.AddTransient<YasamSureci>();
            builder.Services.AddScoped<YasamSureci>();
            builder.Services.AddScoped<Test>();

            // builder.Services.AddSingleton<YasamSureci>();



            // asp.net core'da kendi servislerimizi (instacance) aya�a kald�rmak i�in yani container'a eklemek i�in kullan�lan metotlard�r
            // DI lifetime;

            // Transient => s�rekli yeni instance. instance ihtiya� oldu�unda yeni bir intance olu�turup payla��r..
            // Scoped   =>  Request bazl� olu�turur. bir requestte 5 instance ihtiya� varsa bir kere olu�tur ve  instance da��t�l�r. 
            // Singleton => Uygulama aya�a kalkt���nda bir kere olu�turur. Dikkatli kullan�lmas� gerekir...
            //builder.Services.AddTransient();
            //builder.Services.AddScoped();
            //builder.Services.AddSingleton();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}