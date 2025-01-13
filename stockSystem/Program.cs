using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using stockSystem.Dtos;
using stockSystem.Repository.Implementation;
using stockSystem.Repository.Interfaces;
using stockSystem.Services;
using stockSystem.Services.Interfaces;
using StockSystem.dataAccess.context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<stockSystemContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("db")));
string policy = "MyPolicy";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policy, builder =>
      builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
      .AllowAnyHeader().AllowAnyMethod());

});

var cloudinaryConfig = builder.Configuration.GetSection("Cloudinary");
var cloudinary = new Cloudinary(new Account(
    cloudinaryConfig["CloudName"],
    cloudinaryConfig["ApiKey"],
    cloudinaryConfig["ApiSecret"]
    ));

builder.Services.AddSingleton(cloudinary);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseAuthorization();

app.MapControllers();
app.UseCors(policy);
app.Run();
