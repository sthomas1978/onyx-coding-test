using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Onyx.Products.Web.Api.Data;
using System.Text;

namespace Onyx.Products.Web.Api;

public static class WebApplicationBuilderExtensions
{
    public const string MySecretKey = "this is a really massively long long long long long secret";
    public static WebApplicationBuilder AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "onyx-issuer",
                    ValidAudience = "onyx-audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MySecretKey))
                };
            });
        builder.Services.AddAuthorization();

        return builder;
    }

    public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ProductsContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsContext")));

        return builder;

    }
}
