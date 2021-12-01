using Dominio;
using Microsoft.AspNetCore.Mvc;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlueBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICoreRepository _repo;
        public ClienteController(ICoreRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ClienteController>
        /// <summary>
        /// Retorna lista com TODOS os clientes
        /// </summary>
        /// <returns code="200">Retorna lista com TODOS os clientes</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _repo.GetAllClientes();

                return Ok(clientes);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }
        }

        // GET api/<ClienteController>/5
        /// <summary>
        /// Retorna o cliente com o id passado no request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var clientes = await _repo.GetClienteById(id);

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            
        }

        // POST api/<ClienteController>
        /// <summary>
        /// Insere um cliente 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Cliente model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
                {
                    return Ok();
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Não Salvou");
        }

        // PUT api/<ClienteController>/5
        /// <summary>
        /// Atualiza o cliente com o id passado no parametro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cliente model)
        {
            try
            {
                var movimento = await _repo.GetClienteById(id);

                if (movimento != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                        return Ok();
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest($"Não Atualizado");
        }

        // DELETE api/<ClienteController>/5
        /// <summary>
        /// Deleta o cliente com o id passado no parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetClienteById(id);

                if (heroi != null)
                {
                    _repo.Delete(heroi);

                    if (await _repo.SaveChangeAsync())
                        return Ok("BAZINGA");
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest($"Não Deletado");
        }
    }
}
