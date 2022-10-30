using AspNetCoreMiddleware.AppExtension;
using AspNetCoreMiddleware.AppMiddleeare;

namespace AspNetCoreMiddleware
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            // 3 adet middleware yap�s� vard�r...
            //app.Use(); // Request ile response aras�na girer ve bir sonraki midlleware tetiklenir...
            //app.Map() // Belirli bir path'a request yap�ld���nda tetiklenir.
            //app.Run(); // K�sadevre middleware'd�r. kendisinden sornaki middleware tetiklenmez...

            // Kendi middlewarelerimiz aya�a kald�rmak i�in kullan�l�r...
            //app.UseMiddleware();

            //app.UseMiddleware<RequestDetailMiddleware>(); // middlewarei httprequest pipeline ekle
            //app.UseMiddleware<YetkiMiddleware>();

            app.UseRequestDetail();
            app.UseYetki();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}