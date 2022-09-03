using BookStore.Application.Security;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;

#region ConnectionString
builder.Services.AddDbContext<BookStoreContext>(options =>
{
    options.UseSqlServer(Configuration.GetConnectionString("BookStoreConnection"));
});
#endregion

#region IOC
DependencyContainer.RegisterService(builder.Services);
#endregion

#region Caching
builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();
#endregion

#region JWT

builder.Services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; ;
})
    .AddJwtBearer(jwt =>
    {
        var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
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



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
}

app.UseRouting();
app.UseCors("Policy");
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCaching();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();