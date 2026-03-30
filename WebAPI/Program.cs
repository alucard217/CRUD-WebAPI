using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Services;
using WebAPI.DataAccess;
using WebAPI.DataAccess.Repositories;
using WebAPI.Domain.Abstractions;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VideoStoreDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IVideosRepository, VideosRepository>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseAuthorization();

app.MapControllers();

app.Run();
