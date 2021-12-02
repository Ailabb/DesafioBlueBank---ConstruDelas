using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IMovimentoRepository
    {
        Task<Movimento[]> GetAllMovimentos();
        Task<Movimento> GetMovimentoById(int id);
        Task<Movimento> GetMovimentoByOrigemId(int origemId);
        Task<Movimento> GetMovimentoByDestinoId(int destinoId);
        Task<Movimento> Transferencia(double valorTransferencia, int origemId, int destinoId);

    }
}
