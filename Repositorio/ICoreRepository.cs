using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface ICoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<Cliente[]> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task<Cliente[]> GetClienteByNome(string nome);

        Task<Movimento[]> GetAllMovimentos();
        Task<Movimento> GetMovimentoById(int id);
        Task<Movimento> GetMovimentoByOrigemId(int origemId);
        Task<Movimento> GetMovimentoByDestinoId(int destinoId);
        Task<Movimento> Transferencia(double valorTransferencia, int origemId, int destinoId);
    }
}
