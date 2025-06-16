using Microsoft.EntityFrameworkCore;
using MusicSite.Data;
using MusicSite.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SongService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    var songService = scope.ServiceProvider.GetRequiredService<SongService>();
    await songService.SyncAsync();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();
