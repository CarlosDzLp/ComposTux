using ComposTux.BussinesLayer;
using ComposTux.Entities;
using ComposTux.ViewModels;
using System;
using System.Web.Http;

namespace ComposTux.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        BLLogin login = new BLLogin();
        [HttpPost]
        [Route("insertuser")]
        public IHttpActionResult InsertUser([FromBody] UserViewModel user)
        {
            var response = login.InsertUser(user).Result;
            return Ok(response);
        }

        [HttpPut]
        [Route("updateuser")]
        public IHttpActionResult UpdateUser([FromBody] User user)
        {
            var response = login.Update(user).Result;
            return Ok(response);
        }

        [HttpDelete]
        [Route("deleteuser")]
        public IHttpActionResult DeleteUser([FromUri] Guid IdUser)
        {
            var response = login.DeleteUser(IdUser).Result;
            return Ok(response);
        }

        [HttpGet]
        [Route("selectuser")]
        public IHttpActionResult GetUser(string UserName,string Password)
        {
            var response = login.GetUser(UserName, Password).Result;
            return Ok(response);
        }
    }
}
