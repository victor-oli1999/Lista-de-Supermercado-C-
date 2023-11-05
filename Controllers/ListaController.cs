using AutoMapper;
using Lista_de_Supermercado.Models;
using Lista_de_Supermercado.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lista_de_Supermercado.Repository;

namespace AwesomeDevEvents.API.Controllers
{
    [Route("api/ProdutoDTO")]
    [ApiController]
    public class ListaController : ControllerBase
    {
        /// <summary>
        /// Consulta Lista por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var lista = _context.Listas
            //    .SingleOrDefault(d => d.Id == id);

            var ProdRep = new ProdutoRepository();
            var prod = ProdRep.Obter(id);

            if (prod == null) 
            { 
                return NotFound();
            }

            //var listaView = _mapper.Map<ListaViewModel>(lista);

            return Ok(prod);
        }
    }
}
