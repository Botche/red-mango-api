using Azure.Storage.Blobs;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using RedMangoAPI.Database;
using RedMangoAPI.Database.Entities;
using RedMangoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<RedMangoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection"));
});

builder.Services.AddSingleton(u => new BlobServiceClient(
    builder.Configuration.GetConnectionString("ImagesStorageConnection")
));
builder.Services.AddSingleton<IBlobService, BlobService>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<RedMangoDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
