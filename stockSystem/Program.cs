using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using stockSystem.Dtos;
using stockSystem.Repository.Implementation;
using stockSystem.Repository.Interfaces;
using stockSystem.Services;
using stockSystem.Services.Interfaces;
using StockSystem.dataAccess.context;
using Swashbuckle.AspNetCore.Filters;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ISalesService,SalesService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddDbContext<stockSystemContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("db")));

builder.Services.AddAutoMapper(typeof(MappingProfile));
//JWT
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standar Authorization Header using JWTToken",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey

    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer
    (options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration
            .GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


string policy = "MyPolicy";
var allowedOrigins = new[] { "http://localhost", "http://localhost:80", "http://localhost:4200", "http://35.162.201.84", "http://35.162.201.84:80", "http://lacasadetoby.com", "http://lacasadetoby.com:80" };
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policy, builder =>
        builder.WithOrigins(allowedOrigins) // Agrega los orígenes permitidos
               .AllowAnyHeader()
               .AllowAnyMethod());
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


app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();
app.UseCors(policy);
app.Run();
