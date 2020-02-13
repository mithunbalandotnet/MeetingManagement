using MeetingManagement.DL;
using MeetingManagement.DL.Repository.Abstract;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MeetingManagement.Web.Authorisation
{
    public class MMAuthorisationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IRepositoryBase<User> _userRepository;

        public MMAuthorisationServerProvider(IRepositoryBase<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = _userRepository.GetAll().Where(u => u.UserName == context.UserName && u.Password == context.Password).FirstOrDefault();

            if (user == null)
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

            context.Validated(identity);
        }
    }
}
