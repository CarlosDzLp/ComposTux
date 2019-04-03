using ComposTux.BussinesLayer;
using ComposTux.Entities;
using System;
using System.Web.Http;

namespace ComposTux.Controllers
{
    [Authorize]
    [RoutePrefix("api/AssigmentColony")]
    public class AssigmentColonyController : ApiController
    {
        BLAssigmentColony Acolony = new BLAssigmentColony();
        [HttpPost]
        [Route("insertassigmentcolony")]
        public IHttpActionResult InsertAssigmentColony([FromBody] AssigmentColony colony)
        {
            var response = Acolony.Insert(colony).Result;
            return Ok(response);
        }

        [HttpPut]
        [Route("updateassigmentcolony")]
        public IHttpActionResult UpdateAssigmentColony([FromBody] AssigmentColony colony)
        {
            var response = Acolony.Update(colony).Result;
            return Ok(response);
        }

        [HttpDelete]
        [Route("deleteassigmentcolony")]
        public IHttpActionResult DeleteAssigmentColony([FromUri] Guid IdAssigmentColony)
        {
            var response = Acolony.Delete(IdAssigmentColony).Result;
            return Ok(response);
        }

        [HttpGet]
        [Route("selectassigmentcolony")]
        public IHttpActionResult GetAssigmentColony(Guid idUser)
        {
            var response = Acolony.Select(idUser).Result;
            return Ok(response);
        }

        [HttpGet]
        [Route("selectallassigmentcolony")]
        public IHttpActionResult GetAllAssigmentColony()
        {
            var response = Acolony.SelectColony().Result;
            return Ok(response);
        }
    }
}
