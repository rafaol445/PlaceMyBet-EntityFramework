using Api_PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_PlaceMyBet.Controllers
{
    //[Authorize]
    public class ApuestasController : ApiController
    {
        ApuestasRepository apuestaRepository = new ApuestasRepository();
        // GET: api/Apuestas
        
        public IEnumerable<Apuesta> Get()
        {
            return apuestaRepository.Retrive();
        }

        // GET: api/Apuestas/5
        /*
        [Authorize(Roles = "Admin")]
        public IEnumerable<ApuestasPorTipoMercado> Get(double tipoMercado, string email)
        {
            
            Debug.WriteLine(email);
            Debug.WriteLine(tipoMercado);
            return apuestaRepository.ApuestaPorEmailTipoMercado(tipoMercado, email);
        }
        */
       



        // POST: api/Apuestas
        //[Authorize]
        public void Post([FromBody]Apuesta apuesta)
        {
            apuestaRepository.HacerApuesta(apuesta);
        }
        /*
        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }*/
    }
}
