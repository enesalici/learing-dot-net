using Core.Entities;
using Core.Utilities.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JWT
{
    public class JwtHelper
    {
        private readonly TokenOptions _tokenOptions;
      
        public JwtHelper(TokenOptions tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }

        public string CreateToken(BaseUser user)
        {
            DateTime expirationTime = DateTime.Now.AddMinutes(_tokenOptions.ExpirationTime);

            SecurityKey key = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            return "";
        }
    }
}
