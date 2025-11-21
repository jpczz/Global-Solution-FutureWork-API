using Microsoft.EntityFrameworkCore;
using FutureWork.API.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FutureWorkDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

// Swagger (vamos melhorar isso depois com versionamento)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FutureWork API",
        Version = "v1",
        Description = "API para gerenciar competências relacionadas ao Futuro do Trabalho (versão 1).",
        Contact = new OpenApiContact
        {
            Name = "JP (Aluno)",
            Email = "seu-email-aqui@example.com"
        },
        License = new OpenApiLicense
        {
            Name = "MIT License"
        }
    });

    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "FutureWork API",
        Version = "v2",
        Description = "Versão 2 da API, utilizando DTO aprimorado e novas informações sem quebrar a v1.",
        Contact = new OpenApiContact
        {
            Name = "JP (Aluno)",
            Email = "seu-email-aqui@example.com"
        },
        License = new OpenApiLicense
        {
            Name = "MIT License"
        }
    });

    // ESSA PARTE É A CHAVE PARA SEPARAR V1 E V2
    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        var groupName = apiDesc.GroupName ?? "v1"; // se não tiver grupo, assume v1
        return groupName == docName;
    });
});

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FutureWork API V1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "FutureWork API V2");
        c.DocumentTitle = "FutureWork API — Swagger Docs";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
