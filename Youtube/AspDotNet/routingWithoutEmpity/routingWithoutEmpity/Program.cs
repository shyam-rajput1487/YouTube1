using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.MapControllerRoute(            //convention base routing
//    name: "default",
//    pattern: "{controller=Home}/{action=about}/{id?}");

app.MapControllers();               //attribute based routing

app.Run();
