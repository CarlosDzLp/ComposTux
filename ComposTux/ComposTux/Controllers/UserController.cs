using ComposTux.BussinesLayer;
using ComposTux.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComposTux.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        BLLogin login = new BLLogin();
        [HttpPost]
        [Route("insertuser")]
        public IHttpActionResult InsertUser(UserViewModel user)
        {
            var response = login.InsertUser(user).Result;
            return Ok(response);
        }


        [HttpPut]
        [Route("updateuser")]
        public IHttpActionResult UpdateUser(UserViewModel user)
        {
            var isValid = login.UpdateUser(user).Result;
            return Ok(isValid);
        }


        [HttpGet]
        [Route("selectuser")]
        public IHttpActionResult SelectUser(string UserName,string Password)
        {
            var isValid = login.DoLogin(UserName, Password).Result;
            return Ok(isValid);
        }
    }
}
