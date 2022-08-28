using BookStore.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region ConnectionString
builder.Services.AddDbContext<BookStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreConnection"));
});
#endregion

#region IOC

#endregion

#region Caching
builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();
#endregion

#region JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("UnKhownKey"))
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy", services =>
    {
        services.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyOrigin()
        .Build();
    });
});

#endregion

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
});



var app = builder.Build();

app.UseRouting();
app.UseCors("Policy");
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasketAPI v1"));
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();