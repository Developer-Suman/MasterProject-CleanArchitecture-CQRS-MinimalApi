using Application;
using Infrastructure;
using Infrastructure.Seed;
using Presentation;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddSwaggerGen();

ConfigurationManager configuration = builder.Configuration;
builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await dataSeeder.Seed();
}





if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.AddEndPoint();
app.UseAntiforgery();

app.Run();

