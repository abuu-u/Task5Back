namespace Task5Back.Authorization
{
    public class NameMiddleware
    {
        private readonly RequestDelegate _next;

        public NameMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["Name"] = (context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last());

            await _next(context);
        }
    }
}