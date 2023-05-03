using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using locadoraDeCarros.Data;
using locadoraDeCarros.Models;
using locadoraDeCarros.Dtos;
using Microsoft.EntityFrameworkCore;

namespace locadoraDeCarros.Controllers
{
    [ApiController]
    [Route("carro")]
    public class CarroController : ControllerBase
    {
        public CarroController(
            [FromServices] LocacaoContext context
        )
        {
            Context = context;
        }

        public LocacaoContext Context { get; set; }

    [HttpPost]
        public ActionResult<CarroModel> Create(
            [FromBody] CarroRequestDTO dto)
        {
            var carro = new CarroModel();
            carro.Nome = dto.DescricaoCarro;

             var marca = Context.Marcas.FirstOrDefault(m => m.Id == dto.MarcaId);
            if (marca == null)
            {
                var novaMarca = new MarcaModel();
                novaMarca.Nome = dto.DescricaoMarca;
            
                carro.Marca = novaMarca;
            } else {
                carro.Marca = marca;
            }

            Context.Carros.Add(carro);
            Context.SaveChanges();

            return Created($"/{carro.Id}", carro);

        }

        [HttpPut("{id}")]
        public ActionResult<CarroModel> Update(
            [FromRoute] int id,
            [FromBody] CarroRequestDTO dto)
        {

            var carro = Context.Carros.FirstOrDefault(c => c.Id == id);
            if (carro == null)
            {
                return NotFound("Marca não encontrada.");
            }

            carro.Nome = dto.DescricaoCarro;

            Context.Carros.Update(carro);
            Context.SaveChanges();

            return Ok(carro);

        }

        [HttpDelete("{id}")]
        public ActionResult<CarroModel> Delete(
            [FromRoute] int id
            )
        {

            var carro = Context.Carros.FirstOrDefault(c => c.Id == id);
            if (carro == null)
            {
                return NotFound("Carro não encontrado.");
            }



            Context.Carros.Remove(carro);
            Context.SaveChanges();

            return NoContent();

        }

        [HttpGet]
        public ActionResult<List<CarroModel>> Get()
        {
            var listaDeCarros = Context.Carros
            .Include(c => c.Marca)
            .ToList();

            return Ok(listaDeCarros);
        }

         [HttpGet("{id}")]
        public ActionResult<List<CarroModel>> GetById(
            [FromRoute] int id
        )
        {
            var carro = Context.Carros
            .Include(c => c.Marca)
            .FirstOrDefault(c => c.Id == id);

            if (carro == null) {
                return NotFound("Carro não encontrado.");
            }

            return Ok(carro);
        }
    }
}