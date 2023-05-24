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

//ICategoryServices kar��la�t��� zaman CategoryServices'ten nesne �rne�i getirir.
builder.Services.AddScoped<ICategoryService, CategoryService>();

//IProductService kar��la�t��� zaman ProductService'ten nesne �rne�i getirir.
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//de�i�meyen de�erler oldu�u i�in singeton kullan�ld�.
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
//ilgili servisi bulmamas� durmunda GetRequiredService kullan�l�r.
//IOptions �zerinden DatabaseSettings de�eri al�n�r Value ile de�erler geri d�nd�r�l�r.
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
//appsettingste bulunan verileri "DatabaseSettings" e ba�lar.
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
