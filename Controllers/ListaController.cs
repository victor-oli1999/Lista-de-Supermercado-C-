using AutoMapper;
using AwesomeDevEvents.API.Entities;
using Lista_de_Supermercado.Models;
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
        private readonly IMapper _mapper;
        public ListaController(
            ListaDbContext context,
            IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Consulta todas as Listas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() 
        {
            //var Lista = _context.Listas.Where(d => d.IsAtivo).ToList(); 
            var lista = _context.Listas.ToList();

            var listaView = _mapper.Map<List<ListaViewModel>>(lista);

            return Ok(listaView);
        }

        /// <summary>
        /// Consulta Lista por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(short id)
        {
            var lista = _context.Listas
                .Include(de => de.Item)
                .SingleOrDefault(d => d.Id == id);

            if (lista == null) 
            { 
                return NotFound();
            }

            var listaView = _mapper.Map<ListaViewModel>(lista);

            return Ok(listaView);
        }

        /// <summary>
        /// Insere lista nova
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ListaInputModel input)
        {
            var listaInput = _mapper.Map<Lista>(input);

            _context.Listas.Add(listaInput);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = listaInput.Id }, listaInput);
        }

        /// <summary>
        /// Atualiza lista por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(short id, ListaInputModel input)
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

        /// <summary>
        /// Desativa lista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Desativo(short id)
        {
            var lista = _context.Listas.SingleOrDefault(d => d.Id == id);
            if (lista == null)
            {
                return NotFound();
            }

            lista.Desativo();

            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Insere o item de uma lista
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost("{id}/Itens")]
        public IActionResult PostItem(short id, ListaItemInputModel input)
        {
            var item = _mapper.Map<ListaItem>(input);

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

        /// <summary>
        /// Ativa lista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Ativado")]
        public IActionResult Ativo(short id)
        {
            var lista = _context.Listas.SingleOrDefault(d => d.Id == id);
            if (lista == null)
            {
                return NotFound();
            }

            lista.Ativo();

            _context.SaveChanges();

            return NoContent();
        }
    }
}
