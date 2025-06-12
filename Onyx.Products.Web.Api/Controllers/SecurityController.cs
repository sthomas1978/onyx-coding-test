using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Onyx.Products.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityController : ControllerBase
{
    [HttpGet("GenerateToken")]
    public IActionResult GenerateToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[] {
                    new(ClaimTypes.Name, "joe")
                    }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(WebApplicationBuilderExtensions.MySecretKey)),
                SecurityAlgorithms.HmacSha256Signature),
            Issuer = "onyx-issuer",
            Audience = "onyx-audience",
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        // Return the token to the client
        return Ok(new { Token = tokenString });
    }

}
