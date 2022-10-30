using AspNetCoreMiddleware.AppMiddleeare;

namespace AspNetCoreMiddleware.AppExtension
{
    public static class AppExtension
    {
        // bakınız extension metod
        // this ifadesi metotu çağıran isntance anlamına gelir...

        // metotlarımız IApplicationBuilder extent edildi. artık bu tip üzerinden bu metotlara erişebiliriz...


        public static IApplicationBuilder UseRequestDetail(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestDetailMiddleware>();
        }

        public static IApplicationBuilder UseYetki(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<YetkiMiddleware>();
        }
    }
}
