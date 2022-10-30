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


            // YasamSureci instance'ina ihtiyacý olan herkes instance almasý için instance container'a registir edilir...
            //   builder.Services.AddTransient<YasamSureci>();
            builder.Services.AddScoped<YasamSureci>();
            builder.Services.AddScoped<Test>();

            // builder.Services.AddSingleton<YasamSureci>();



            // asp.net core'da kendi servislerimizi (instacance) ayaða kaldýrmak için yani container'a eklemek için kullanýlan metotlardýr
            // DI lifetime;

            // Transient => sürekli yeni instance. instance ihtiyaç olduðunda yeni bir intance oluþturup paylaþýr..
            // Scoped   =>  Request bazlý oluþturur. bir requestte 5 instance ihtiyaç varsa bir kere oluþtur ve  instance daðýtýlýr. 
            // Singleton => Uygulama ayaða kalktýðýnda bir kere oluþturur. Dikkatli kullanýlmasý gerekir...
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