namespace AspNetCoreMiddleware.AppMiddleeare
{
    public class YetkiMiddleware
    {
        RequestDelegate _next;
        public YetkiMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Request Header'da client'ın username ve pasword göndermesi beklenir. Request Header tanımlı keyler olduğu gibi kendi key ve valuemuzda gönderebiliriz

            string userName = context.Request.Headers["username"];
            string pwd = context.Request.Headers["password"];

            if (userName == "admin" && pwd == "123")
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = 401; //UnAuthorize
               await context.Response.WriteAsync("bu servisi kullanmaya yetkin yok");
            }
        }
    }
}