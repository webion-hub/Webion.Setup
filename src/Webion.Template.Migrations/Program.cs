using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Webion.Template.Storage.Extensions;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddStorage(options =>
{
    var conn = builder.Configuration.GetConnectionString("default");
    
    options.UseNpgsql(conn, b =>
    {
        b.MigrationsAssembly("Webion.Template.Migrations");
        b.UseNodaTime();
    });
});

var app = builder.Build();

app.Run();