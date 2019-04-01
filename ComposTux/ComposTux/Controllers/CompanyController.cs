using ComposTux.BussinesLayer;
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
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        BLCompany blcompany = new BLCompany();
        [HttpPost]
        [Route("insertcompany")]
        public IHttpActionResult InsertUser(Company company)
        {
            var response = blcompany.InsertCompany(company).Result;
            return Ok(response);
        }

        [HttpPut]
        [Route("updatecompany")]
        public IHttpActionResult UpdateUser(Company company)
        {
            var response = blcompany.UpdateCompany(company).Result;
            return Ok(response);
        }

        [HttpGet]
        [Route("selectcompany")]
        public IHttpActionResult SelectUser(Guid IdUser)
        {
            var response = blcompany.SelectCompany(IdUser).Result;
            return Ok(response);
        }

        [HttpGet]
        [Route("selectcompanyall")]
        public IHttpActionResult SelectCompanyAll()
        {
            var response = blcompany.SelectCompanyAll().Result;
            return Ok(response);
        }
    }
}
