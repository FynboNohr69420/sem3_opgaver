using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Claims;
using System.Text.Encodings.Web;

public class DummyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public DummyAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
        ) : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // Vi undersøge lige om anonym adgang er tilladt
        var endpoint = Context.GetEndpoint();
        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        {
            // Hvis anonym adgang er tilladt, skal vi ikke lave authentication
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        // Vi fisker en header ud hvor key er "Authorization"
        var authHeader = Request.Headers["Authorization"].ToString();
        var userHeader = Request.Headers["User"].ToString();

        // Vi tjekker efterfølgende på om "Authorization" findes, og på om dens value starte med "Password".
        if (userHeader != null && authHeader != null && authHeader.StartsWith("Password", StringComparison.OrdinalIgnoreCase) && userHeader.StartsWith("User", StringComparison.OrdinalIgnoreCase))
        {
            // OBS: User - Admin = password123 | User - Cake = cake123
            var user = userHeader.Substring("User ".Length).Trim();
            var password = authHeader.Substring("Password ".Length).Trim();
            string salt = "";

            if (user == "Cake")
            {
                salt = "SALT";
            }
            else if (user == "Admin")
            {
                salt = "BAST";
            }
            // Lav en 256-bit hash af "password + salt" - og gør det 100.000 gange!
            // HMACSHA256 er navnet på hash-funktionen der anvendes herunder
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            //Console.WriteLine($"Password {password} plus salt {salt} er hashed til {hashed}");

            password = "."; //Sletter password værdi for god ordens skyld

            Console.WriteLine($"Password value now cleared. Current password value: {password}");


            // Nu tjekkes om password er korrekt
            if (hashed == "C0xbkbdKyAWB6aJhOo7FmmKjuv2K0fY53ivjbPG+EZQ=")
            {
                // Vi opretter et "claim"
                var claims = new[] { new Claim("Role", "Admin") };
                var identity = new ClaimsIdentity(claims);
                var claimsPrincipal = new ClaimsPrincipal(identity);

                // Claim returneres og giver nu adgang til endpoints der i deres 
                // policty har "Role = Admin".
                return Task.FromResult(AuthenticateResult.Success(
                    new AuthenticationTicket(claimsPrincipal, "DummyAuthentication")));
            }
            if (hashed == "ElXiGE4kL81C3tFWuO/nKzOz0rkWiME/IFUF3zeLAa8=")
            {
                // Vi opretter et "claim"
                var claims = new[] { new Claim("Role", "CakeLover") };
                var identity = new ClaimsIdentity(claims);
                var claimsPrincipal = new ClaimsPrincipal(identity);

                // Claim returneres og giver nu adgang til endpoints der i deres 
                // policty har "Role = CakeLover".
                return Task.FromResult(AuthenticateResult.Success(
                    new AuthenticationTicket(claimsPrincipal, "DummyAuthentication")));
            }
        }
        else if(userHeader == null || userHeader == "")
        {
            Response.StatusCode = 401;
            return Task.FromResult(AuthenticateResult.Fail("Please enter a User header"));
        }
        else if (authHeader == null || authHeader == "")
        {
            Response.StatusCode = 401;
            return Task.FromResult(AuthenticateResult.Fail("Please enter a Authentication header"));
        }
        Response.StatusCode = 401;
        return Task.FromResult(AuthenticateResult.Fail("Invalid Password or User"));  
    }
}