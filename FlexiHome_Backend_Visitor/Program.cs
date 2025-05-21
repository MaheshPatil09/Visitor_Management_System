using FlexiHome_Backend_Visitor.Common;
using FlexiHome_Backend_Visitor.DatabaseLayer;
using FlexiHome_Backend_Visitor.DbContext;
using FlexiHome_Backend_Visitor.Helper;
using FlexiHome_Backend_Visitor.VisitorService;
using FlexiHome_Backend_Visitor.VistorInterface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IVisitor, VisitorService>();
builder.Services.AddScoped<IDatabase, Database>();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
