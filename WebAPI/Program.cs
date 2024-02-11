using Application;
using Asp.Versioning;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "Country API", Version = "v1.0" });
        options.SwaggerDoc("v1.1", new OpenApiInfo { Title = "Country API", Version = "v1.1" });
    });
    builder.Services.AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = false;
        options.ReportApiVersions = true;
        options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
    }).AddApiExplorer(options => 
    {
        options.GroupNameFormat = "'v'VVV"; //swagger dokümantasyonunda version combosunda versiyon bilgisi major.minor.patch format görünecek.
        options.SubstituteApiVersionInUrl = true; //swagger dokümantasyonunda version combosunda seçilen versiyon değeri ep route bilgisine geçilecek.
    });

    builder.Services.AddHealthChecks();

    builder.Services.AddHttpLogging(options =>
    {
        options.LoggingFields = HttpLoggingFields.All;
        //logging.RequestHeaders.Add("x-correlation-id");
    });

    builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration)
    );

    builder.Services.AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1.0");
            options.SwaggerEndpoint("/swagger/v1.1/swagger.json", "v1.1");
        });
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.MapHealthChecks("/health");

    app.UseHttpLogging();

    app.Run();
}