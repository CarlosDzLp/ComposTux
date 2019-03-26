using ComposTux.Secutiry;
using ComposTux.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace ComposTux.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/authentication")]
    public class TokenController : ApiController
    {
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(TokenRequest token)
        {
            if (token == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var isValid = true;
            if (isValid)
            {
                var rolename = "Admin";
                var response = TokenGenerator.GenerateTokenJwt(token.UserName, rolename);
                return Ok(token);
            }
            
            return Unauthorized();
        }
    }
}
