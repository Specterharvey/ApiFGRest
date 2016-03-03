using ApiFGRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiFGRest.Controllers
{
    [RoutePrefix("api/Prof")]
    public class ProfController : ApiController
    {
        private FgEntities fg = new FgEntities();

        [Route("AutenProfe")]
        public HttpResponseMessage Autenticar(AutenticarProfessorModel autenticar)
        {
            try
            {
                var usuario = fg.Professor.SingleOrDefault(x => x.Nome == autenticar.nome
                && x.Senha == autenticar.senha);

                if (usuario != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Logado");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,"Senha Incorreta");
                }    
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("ListProf")]
        public HttpResponseMessage List(AutenticarProfessorModel autenticar)
        {
            try
            {
                var retorno = fg.Professor.Where(x => x.Nome == autenticar.nome &&
                x.Senha == autenticar.senha).AsEnumerable<Professor>();
                if (retorno != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, retorno);
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

        [Route("PostMen")]
        public HttpResponseMessage PostM(Push push)
        {
            try
            {
                fg.Push.Add(push);
                fg.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Menssagem Enviada com Sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
