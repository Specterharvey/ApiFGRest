using ApiFGRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiFGRest.Controllers
{
    [RoutePrefix("api/PushIn")]
    public class PushInController : ApiController
    {
        FgEntities fg = new FgEntities();

        [Route("PushM")]
        public HttpResponseMessage Push(PushMessageModel push)
        {
            try
            {
                var lista = fg.Push.Where(x => x.Curso == push.curso && x.Turno == push.turno
                && x.Periodo == push.periodo && x.Semestre == push.semestre).AsEnumerable<Push>();

                if (lista != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lista);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "ERROR");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }       
    }
}
