using Dominio;
using Microsoft.AspNetCore.Mvc;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly ICoreRepository _repo;
        public TransferenciaController(ICoreRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<TransferenciaController>
        /// <summary>
        /// Retorna uma lista com todas as movimentações
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var movimentos = await _repo.GetAllMovimentos();

                return Ok(movimentos);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // GET api/<TransferenciaController>/5
        /// <summary>
        /// retorna uma moviemntação especifica atraves do id da movimentação
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransferenciaController>
        /// <summary>
        /// insere as movimentações no caso a transferencia 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Movimento model)
        {
            try
            {                
                return Ok(await _repo.Transferencia(model.Valor, model.OrigemId, model.DestinoId));                

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
            
        }
    }
}
