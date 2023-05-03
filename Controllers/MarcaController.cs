using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using locadoraDeCarros.Data;
using locadoraDeCarros.Models;
using locadoraDeCarros.Dtos;

namespace locadoraDeCarros.Controllers
{

    [ApiController]
    [Route("marca")]
    public class MarcaController : ControllerBase
    {
        public MarcaController(
            [FromServices] LocacaoContext context
        )
        {
            Context = context;
        }

        public LocacaoContext Context { get; set; }


        [HttpPost]
        public ActionResult<MarcaModel> Create(
            [FromBody] MarcaRequestDTO dto)
        {
            var marca = new MarcaModel();
            marca.Nome = dto.Nome;

            Context.Marcas.Add(marca);
            Context.SaveChanges();

            return Created($"/{marca.Id}", marca);

        }

        [HttpPut("{id}")]
        public ActionResult<MarcaModel> Update(
            [FromRoute] int id,
            [FromBody] MarcaRequestDTO dto)
        {

            var marca = Context.Marcas.FirstOrDefault(m => m.Id == id);
            if (marca == null)
            {
                return NotFound("Marca não encontrada.");
            }

            marca.Nome = dto.Nome;

            Context.Marcas.Update(marca);
            Context.SaveChanges();

            return Ok(marca);

        }

        [HttpDelete("{id}")]
        public ActionResult<MarcaModel> Delete(
            [FromRoute] int id
            )
        {

            var marca = Context.Marcas.FirstOrDefault(m => m.Id == id);
            if (marca == null)
            {
                return NotFound("Marca não encontrada.");
            }



            Context.Marcas.Remove(marca);
            Context.SaveChanges();

            return NoContent();

        }

        [HttpGet]
        public ActionResult<List<MarcaModel>> Get()
        {
            var listaDeMarcas = Context.Marcas.ToList();

            return Ok(listaDeMarcas);
        }

         [HttpGet("{id}")]
        public ActionResult<List<MarcaModel>> GetById(
            [FromRoute] int id
        )
        {
            var marca = Context.Marcas.FirstOrDefault(m => m.Id == id);

            if (marca == null) {
                return NotFound("Marca não encontrada.");
            }

            return Ok(marca);
        }


    }





}