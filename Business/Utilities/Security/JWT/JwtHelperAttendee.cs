using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Security.JWT
{
    public class JwtHelperAttendee:ITokenHelperAttendee
    {
        public IConfiguration Configuration { get; }  //appsettings'i okumanı sağlar.
        private TokenOptions _tokenOptions;  //appsettings içindeki değerleri tutacak.
        private DateTime _accessTokenExpiration;

        public JwtHelperAttendee(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            
        }
        public AccessToken CreateToken(Attendee user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }


        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Attendee user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(Attendee user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.AttendeeId.ToString());
            claims.AddEmail(user.AttendeeEmail);
            claims.AddName($"{user.AttendeeName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
