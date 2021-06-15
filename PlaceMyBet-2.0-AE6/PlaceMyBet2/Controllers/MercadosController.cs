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
    public class MercadosController : ApiController
    {
        MercadosRepository mercadoRepository = new MercadosRepository();
        

        // GET: api/Mercados
        
        public IEnumerable<MercadoDTO> Get()
        {
            return mercadoRepository.RetriveDTO();
        }

        // GET: api/Mercados/5
        
        public Mercado Get(int idMercado)
        {

            return mercadoRepository.RetriveMercado(idMercado);
        }

        // POST: api/Mercados
        public void Post([FromBody]Mercado mercado)
        {
            mercadoRepository.GuardarMercado(mercado);
        }

        // PUT: api/Mercados/5
        /*
        public void Put(int id, [FromBody]string value)
        {
        }*/

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
