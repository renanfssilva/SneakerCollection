using Microsoft.AspNetCore.Localization;
using SneakerCollection.API;
using SneakerCollection.Application;
using SneakerCollection.Infrastructure;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = [new CultureInfo("en-US")],
    SupportedUICultures = [new CultureInfo("en-US")]
});

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
