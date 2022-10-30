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



            // 3 adet middleware yapýsý vardýr...
            //app.Use(); // Request ile response arasýna girer ve bir sonraki midlleware tetiklenir...
            //app.Map() // Belirli bir path'a request yapýldýðýnda tetiklenir.
            //app.Run(); // Kýsadevre middleware'dýr. kendisinden sornaki middleware tetiklenmez...

            // Kendi middlewarelerimiz ayaða kaldýrmak için kullanýlýr...
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