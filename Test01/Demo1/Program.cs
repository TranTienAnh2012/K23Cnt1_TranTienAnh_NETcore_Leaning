var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "TRAN TIEN ANH !");

app.Run();
