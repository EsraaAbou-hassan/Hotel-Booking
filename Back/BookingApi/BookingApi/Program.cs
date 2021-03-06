using BookingApi.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookingApi.Models;
using BookingApi.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.FileProviders;
using BookingApi;
//using System.Web.HttpUtility.Cors;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddCors();

builder.Services.AddDbContext<Bookingdb>(a => { a.UseSqlServer(builder.Configuration.GetConnectionString("con")); });


builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<Bookingdb>();
//builder.Services.AddScoped<RoleServices,RoleServices>();
builder.Services.AddCors();

builder.Services.AddDirectoryBrowser();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Booking", Version = "v1" });
});
builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation    
    swagger.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v1",
        Title = "Booking",
        Description = "Hotel Booking"
    });

    // To Enable authorization using Swagger (JWT)    
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                    }
                    },
                    new string[] {}
                    }
                });
});


builder.Services.AddDirectoryBrowser();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(o=>o.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking v1"));
}


app.UseHttpsRedirection();
app.UseCors(s=>s.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseStaticFiles();


var fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath, "Images"));
var requestPath = "/Images";


app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});
RoleServices RoleServices = new RoleServices();
RoleServices.CreatedRole_User();
//app.UseMiddleware<RoleServices>();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.Run();
