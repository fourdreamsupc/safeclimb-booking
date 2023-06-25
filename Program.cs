using Mapping;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence.Contexts;
using Microsoft.OpenApi.Models;
using Shared.Domain.Repositories;
using Shared.Persistence.Repositories;
using HiredServices.Domain.Repositories;
using HiredServices.Domain.Services;
using Services.Domain.Repositories;
using Services.Domain.Services;
using HiredServices.Services;
using HiredServices.Persistence.Repositories;
using Services.Persistence.Repositories;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // Add API Documentation Information
        
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Booking Context - SafeClimb API",
        Description = "Booking Context including Services and Hired Services",
        TermsOfService = new Uri("https://outsidersstartup.github.io/Go2Climb-Landing-Page/"),
        Contact = new OpenApiContact
        {
            Name = "SafeClimb.studio",
            Url = new Uri("https://outsidersstartup.github.io/Go2Climb-Landing-Page/")
        },
        License = new OpenApiLicense
        {
            Name = "SafeClimb Resources License",
            Url = new Uri("https://outsidersstartup.github.io/Go2Climb-Landing-Page/")
        }
    });
    options.EnableAnnotations();
});

// Add Database Connection

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString = builder.Configuration.GetConnectionString("AzureDbConnection");
// Database Connection with Standard Level for Information and Errors

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

// Add lowercase routes

builder.Services.AddRouting(options => 
options.LowercaseUrls = true);
builder.Services.AddScoped<IHiredServiceRepository, HiredServiceRepository>();
builder.Services.AddScoped<IHiredServiceService, HiredServiceService>();

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
