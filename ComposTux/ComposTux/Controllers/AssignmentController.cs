using ComposTux.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComposTux.Controllers
{
    [Authorize]
    [RoutePrefix("api/assignment")]
    public class AssignmentController : ApiController
    {
        BussinesLayer.BLAssingment bLAssingment = new BussinesLayer.BLAssingment();
        [HttpPost]
        [Route("insertassignment")]
        public IHttpActionResult Insertassignment(AssignUserCompany assignUserCompany)
        {
            var response = bLAssingment.InsertAssignUserCompany(assignUserCompany).Result;
            return Ok(response);
        }

        [HttpGet]
        [Route("selectassigmentUser")]
        public IHttpActionResult SelectAssigmentUser(Guid IdUser)
        {
            var response = bLAssingment.SelectAssignUserCompany(IdUser).Result;
            return Ok(response);
        }
    }
}
