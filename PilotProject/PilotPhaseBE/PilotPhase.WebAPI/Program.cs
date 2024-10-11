using MongoDB.Driver;
using PilotPhase.Application.Commands.ContactForm;
using PilotPhase.Application.Commands.ProductCommand;
using PilotPhase.Domain.Interfaces;
using PilotPhase.Infrastructure.Repositories;
using PilotPhase.Infrastructure.Security;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// MongoDB connection string (replace this with your actual MongoDB connection string)
var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDbConnection");

// Access configuration
var configuration = builder.Configuration;

//// Use the configuration object to access settings
var aesKey = configuration["AES:Key"];
var aesIV = configuration["AES:IV"];

// Register MongoDB Client
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    return new MongoClient(mongoConnectionString);
});

// Register your repository with MongoDB
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IContactFormRepository, ContactFormRepository>();

// Register the EncryptionService
// Register the encryption service
builder.Services.AddSingleton<IEncryptionService, EncryptionService>();


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(CreateProductCommand).Assembly);
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(CreateContactFormCommand).Assembly);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.AllowAnyOrigin()
// Replace with your Angular app's URL
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();



