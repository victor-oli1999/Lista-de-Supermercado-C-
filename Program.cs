using Lista_de_Supermercado.Interface;
using Lista_de_Supermercado.Mappers;
using Lista_de_Supermercado.Persistence;
using Lista_de_Supermercado.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var listaConnectionString = builder.Configuration.GetConnectionString("ProdutoTrabalhoCs");

//builder.Services.AddSingleton<DevEventsDbContext>();
// builder.Services.AddDbContext<DevEventsDbContext>(o => o.UseInMemoryDatabase("DevEventsDb"));

builder.Services.AddDbContext<ProdutoDbContext>(o => o.UseSqlServer(listaConnectionString));
//builder.Services.AddDbContext<ListaDbContext>(o => o.UseSqlServer(listaConnectionString));
builder.Services.AddAutoMapper(typeof(ProdutoProfile));
builder.Services.AddScoped<IUpdateProduto, UpdateProduto>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AwesomeDevEvents.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Victor",
            Email = "victor.oliveira@teste.com.br"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
