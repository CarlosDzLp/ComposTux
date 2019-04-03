using ComposTux.BussinesLayer;
using ComposTux.Entities;
using ComposTux.ViewModels;
using System;
using System.Linq;
using System.Web.Http;

namespace ComposTux.Controllers
{
    [Authorize]
    [RoutePrefix("api/InformationCartel")]
    public class InformationCartelController : ApiController
    {
        BLInformationCartel cartel = new BLInformationCartel();

        [HttpPost]
        [Route("insertinformationcartel")]
        public IHttpActionResult InsertAssigmentColony([FromBody] InformationCartelViewModel info)
        {
            var response = cartel.Insert(info).Result;
            return Ok(response);
        }

        [HttpPut]
        [Route("updateinformationcartel")]
        public IHttpActionResult UpdateAssigmentColony([FromBody] InformationCartel info)
        {
            var response = cartel.Update(info).Result;
            return Ok(response);
        }

        [HttpDelete]
        [Route("deleteinformationcartel")]
        public IHttpActionResult DeleteAssigmentColony([FromUri] Guid IdInformation)
        {
            var response = cartel.Delete(IdInformation).Result;
            return Ok(response);
        }

        [HttpGet]
        [Route("selectinformationcartel")]
        public IHttpActionResult GetAssigmentColony(Guid idUser)
        {
            var response = cartel.Select(idUser).Result;
            return Ok(response);
        }

        [HttpGet]
        [Route("selectallinformationcartel")]
        public IHttpActionResult GetAllAssigmentColony()
        {
            var response = cartel.SelectAll().Result;
            return Ok(response);
        }
    }
}
