using ApiFGRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiFGRest.Controllers
{
    [RoutePrefix("api/alun")]
    public class AlunController : ApiController
    {
        private string me = "Logado";
        private FgEntities fg = new FgEntities();

        [Route("AutenAluno")]
        public HttpResponseMessage Autenticar(AutenticarAlunoModel autenticar)
        {
            try
            {
                var usuario = fg.Aluno.SingleOrDefault(x => x.Nome == autenticar.nome
                && x.Senha == autenticar.senha);

                if (usuario != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, me);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Senha Incorreta");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("ListarCurso")]
        public HttpResponseMessage List(AutenticarAlunoModel autenticar)
        {
            try
            {
                var retorno = fg.Aluno.Where(x => x.Nome == autenticar.nome &&
                x.Senha == autenticar.senha).AsEnumerable<Aluno>();
                    /*SingleOrDefault(x => x.Nome == autenticar.nome &&
                x.Senha == autenticar.senha);*/
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
                return Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
            }
        }

        [Route("GetId")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var retorno = fg.Aluno.SingleOrDefault(x => x.idAluno == id);
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
    }
}
