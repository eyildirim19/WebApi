using System.Text.Json;

namespace AspNetCoreMiddleware.AppMiddleeare
{

    // Request detaylarını sorgulamak iiçn kullanılan modüldür...
    public class RequestDetailMiddleware
    {
        RequestDelegate _next;
        public RequestDetailMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // bir önceki middleware'dan HttpContext (request detayı) alınır
        public async Task Invoke(HttpContext context)
        {
            string url = context.Request.Path; // requestin url'ini al...
            string method = context.Request.Method; // request type
            IQueryCollection query = context.Request.Query; // requst parametresi
            IHeaderDictionary headers = context.Request.Headers;

            string headerBilgi = JsonSerializer.Serialize(context.Request.Headers);
            // request detayını logla..


            // sonraki middleware geç   request detayını aktar..
            await _next(context);
        }
    }
}
