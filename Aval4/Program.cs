using Aval4.BaseDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BingoContext>(options =>
    {
        options.UseInMemoryDatabase("BingoDatabase");
    }
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API PARADIGMAS",
        Description = "Uma API Desenvolvida em ambiente acadêmico da Horus Faculdades",
        Contact = new OpenApiContact
        {
            Name = "Contato",
            Url = new Uri("https://github.com/4biDeN")
        },
        License = new OpenApiLicense
        {
            Name = "Linçenca By eu Mesmo",
            Url = new Uri("https://github.com/4biDeN")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
});

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
