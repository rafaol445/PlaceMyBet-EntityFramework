using Api_PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_PlaceMyBet.Controllers
{
    public class UsuariosController : ApiController
    {
        UsuariosRepository user = new UsuariosRepository();


        // GET: api/Usuarios
        /*
        public IEnumerable<Usuario> Get()
        {
            return user.Retrive();            
        }

        // GET: api/Usuarios/5
        public Usuario Get(int id)
        {            

            return null;
        }

        // POST: api/Usuarios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
        }*/
    }
}
