using ComposTux.Secutiry;
using ComposTux.ViewModels;
using System.Net;
using System.Web.Http;

namespace ComposTux.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Authentication")]
    public class TokenController : ApiController
    {
        BussinesLayer.BLLogin login = new BussinesLayer.BLLogin();
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate([FromBody] TokenRequest token)
        {
            if (token == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var isValid = login.GetUser(token.UserName,token.Password).Result;
            if(isValid.Result != null)
            {
                var rolename = "Admin";
                var response = TokenGenerator.GenerateTokenJwt(token.UserName, rolename);
                return Ok(response);
            }
            return BadRequest("Credential Invalid");
        }
    }
}
