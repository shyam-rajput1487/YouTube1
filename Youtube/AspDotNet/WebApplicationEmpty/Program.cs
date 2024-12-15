var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Use(async(context,next) =>
{
    await context.Response.WriteAsync("welcome asp\n");
    await next(context);
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("welcome asp\n");
    await next(context);
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("welcome asp .net core");
});



app.Run();
