using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using REST.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace REST.Controllers
{
    
    public class UsuarioController : ApiController
    {
        wcfService.ServiceClient wcf = new wcfService.ServiceClient();

        //Obtiene la lista de usuarios registrados
        [HttpGet]
        [Route("usuarios")]
        public List<clsUsuario> getUsuarios()
        {
            List<clsUsuario> usuarios = new List<clsUsuario>();

            String result = wcf.GetUsuarios();
            usuarios = JsonConvert.DeserializeObject<List<clsUsuario>>(result);

            return usuarios;
        }

        //Registrar un nuevo usuario
        [HttpPost]
        [Route("usuarios")]
        public HttpResponseMessage createUsuario([FromBody]JToken request)
        {
            if (request["usuario"] == null)
            {
                HttpResponseMessage m = new HttpResponseMessage(HttpStatusCode.BadRequest);
                m.Content = new StringContent("Property 'nombre' is missing");
                return m;
            }

            if (request["password"] == null)
            {
                HttpResponseMessage m = new HttpResponseMessage(HttpStatusCode.BadRequest);
                m.Content = new StringContent("Property 'password' is missing");
                return m;
            }

            if (request["email"] == null)
            {
                HttpResponseMessage m = new HttpResponseMessage(HttpStatusCode.BadRequest);
                m.Content = new StringContent("Property 'email' is missing");
                return m;
            }

            string r = request.ToString();
            if (wcf.InsertaUsuario(r))
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }


    }
}
