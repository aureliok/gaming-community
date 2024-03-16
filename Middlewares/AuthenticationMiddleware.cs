using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GamingCommunity.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
            _secretKey = "your_secret_key_gaming_community";
            _issuer = "myself";
            _audience = "someone";
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/Community"))
            {
                //if (!context.User.Identity.IsAuthenticated)
                //{
                //    context.Response.Redirect("/api/login");
                //    return;
                //}
                var token = context.Request.Cookies["jwtToken_gcom"];

                if (string.IsNullOrEmpty(token))
                {
                    context.Response.Redirect("/Login");
                    return;
                }

                try
                {
                    var key = Encoding.ASCII.GetBytes(_secretKey);
                    var handler = new JwtSecurityTokenHandler();
                    var principal = handler.ValidateToken(token, new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = _issuer,
                        ValidateAudience = true,
                        ValidAudience = _audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    }, out _);

                    context.User = principal;

                    await _next(context);
                }
                catch
                {
                    context.Response.Redirect("/Authentication/Login");
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}
