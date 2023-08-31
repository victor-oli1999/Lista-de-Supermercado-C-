using AwesomeDevEvents.API.Entities;
using Lista_de_Supermercado.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.API.Controllers
{
    [Route("api/Lista")]
    [ApiController]
    public class ListaController : ControllerBase
    {
        private readonly ListaDbContext _context;

        public ListaController(ListaDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var Lista = _context.Listas.Where(d => d.IsAtivo).ToList();

            return Ok(Lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Lista = _context.Listas
                .Include(de => de.Item)
                .SingleOrDefault(d => d.Id == id);

            if (Lista == null) 
            { 
                return NotFound();
            }

            return Ok(Lista);
        }

        [HttpPost]
        public IActionResult Post(Lista lista)
        {
            _context.Listas.Add(lista);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = lista.Id }, lista);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Lista input)
        {
            var lista = _context.Listas.SingleOrDefault(d => d.Id == id);
            if (lista == null)
            {
                return NotFound();
            }

            lista.Update(input.Nome);

            _context.Listas.Update(lista);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var lista = _context.Listas.SingleOrDefault(d => d.Id == id);
            if (lista == null)
            {
                return NotFound();
            }

            lista.Delete();

            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("{id}/Itens")]
        public IActionResult PostItem(Guid id, ListaItem item)
        {
            item.IdLista = id;

            var lista = _context.Listas.Any(d => d.Id == id);

            if (!lista)
            {
                return NotFound();
            }

            _context.ListaItens.Add(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
