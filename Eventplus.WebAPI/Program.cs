using Eventplus.WebAPI.BdContextEvent;
using Eventplus.WebAPI.Interface;
using Eventplus.WebAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// configurar o contexto do bdd
builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

//2. registrar as repositories 
builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();

//servico que adiciona o swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo 
    {
        Version = "v1",
        Title = "Api de eventos",
        Description = "Aplicacao para gerenciamento de eventos",
        TermsOfService = new Uri("https://exemple.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Matheus Becker",
            Url = new Uri("https://github.com/matheusbeckerstanzione")
        },
        License = new OpenApiLicense
        {
            Name = "License de exemplo",
            Url = new Uri("https://example.com/license")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT"

    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
    });
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger(options => { });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
