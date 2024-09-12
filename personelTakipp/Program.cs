using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using personelTakipp.Extensions;
using Repositories.EfCore;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

//LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/blog.config"));
NLog.LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();

builder.Services.AddControllers(config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true;
    })
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);


builder.Services.Configure<ApiBehaviorOptions>(options =>
{ //???
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddLogging(); //Logging'i ekledik, ILogger altyapýsýný DI sisteme ekler

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureActionFilters();
builder.Services.AddAutoMapper(typeof(Program)); //bunu tek metot olarak çaðýrabildiðimiz için
//extension metot olarak yazmadýk
builder.Services.ConfigureCors();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseCors("CrosPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
