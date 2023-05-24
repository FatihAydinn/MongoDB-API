using Microsoft.Extensions.Options;
using RAS.Services.ProductAPI.Services;
using RAS.Services.ProductAPI.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ICategoryServices karþýlaþtýðý zaman CategoryServices'ten nesne örneði getirir.
builder.Services.AddScoped<ICategoryService, CategoryService>();

//IProductService karþýlaþtýðý zaman ProductService'ten nesne örneði getirir.
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//deðiþmeyen deðerler olduðu için singeton kullanýldý.
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
//ilgili servisi bulmamasý durmunda GetRequiredService kullanýlýr.
//IOptions üzerinden DatabaseSettings deðeri alýnýr Value ile deðerler geri döndürülür.
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
//appsettingste bulunan verileri "DatabaseSettings" e baðlar.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
