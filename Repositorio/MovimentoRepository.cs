using Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class MovimentoRepository : IMovimentoRepository
    {/// <summary>
    /// recebendo contexto de banco de dados por injeção de dependencia 
    /// </summary>
        private readonly BlueBankContext _context;
        public MovimentoRepository(BlueBankContext context)
        {
            _context = context;
        }
        /// <summary>
        /// adicionar uma entidade ao contexto de banco de dados 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>

        public async Task<Movimento[]> GetAllMovimentos()
        {
            IQueryable<Movimento> query = _context.Movimentos;

            return await query.ToArrayAsync();
        }

        public async Task<Movimento> GetMovimentoById(int id)
        {
            IQueryable<Movimento> query = _context.Movimentos;

            return await query.FirstOrDefaultAsync(movimento => movimento.Id == id);
        }

        public async Task<Movimento> GetMovimentoByOrigemId(int idClinteOrigem)
        {
            IQueryable<Movimento> query = _context.Movimentos;

            return await query.FirstOrDefaultAsync(movimento => movimento.OrigemId == idClinteOrigem);
        }

        public async Task<Movimento> GetMovimentoByDestinoId(int idClienteDestino)
        {
            IQueryable<Movimento> query = _context.Movimentos;

            return await query.FirstOrDefaultAsync(movimento => movimento.DestinoId == idClienteDestino);
        }

        public async Task<Movimento> Transferencia(double valorTransferencia, int origemId, int destinoId)
        {
            IQueryable<Cliente> queryOrigem = _context.Clientes;
            IQueryable<Cliente> queryDestino = _context.Clientes;

            var clienteOrigem = await queryOrigem.FirstOrDefaultAsync(clienteOrigem => clienteOrigem.Id == origemId);
            var clienteDestino = await queryDestino.FirstOrDefaultAsync(clientedestino => clientedestino.Id == destinoId);

            Movimento movimento = new Movimento();

            if (clienteOrigem.Saldo >= valorTransferencia)
            {
                movimento.OrigemId = clienteOrigem.Id;
                movimento.DestinoId = clienteDestino.Id;
                movimento.Valor = valorTransferencia;

                //atualiza os saldos dos clientes origem e destino
                clienteOrigem.Saldo = clienteOrigem.Saldo - valorTransferencia;
                clienteDestino.Saldo = clienteDestino.Saldo + valorTransferencia;
            }
            else
            {
                throw new Exception("Saldo insuficiente para realizar a transferência!");
            }

            //atualizando clientes 
            _context.Update(clienteOrigem);
            _context.Update(clienteDestino);

            //adicionando moviemnto
            _context.Add(movimento);

            //confirmando as alterações
            await _context.SaveChangesAsync();

            //retorna o movimento para controller 
            return movimento;
        }
    }
}
