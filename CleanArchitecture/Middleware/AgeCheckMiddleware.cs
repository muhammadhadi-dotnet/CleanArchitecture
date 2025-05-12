namespace CleanArchitecture.Middleware
{
    public class AgeCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public AgeCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context) { 
        
          var AgePar=context.Request.Query["age"].ToString();

            if (int.TryParse(AgePar, out int age) && age>20)
            {
                await _next(context); // Call the next middleware in the pipeline
            }
            else
            {
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Access denied. You must be 18 or older.");
            }
            
        }
    }
}
