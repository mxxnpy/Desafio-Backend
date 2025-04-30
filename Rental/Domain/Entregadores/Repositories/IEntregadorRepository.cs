using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuRental.Domain.Entregadores.Entities;

namespace MottuRental.Domain.Entregadores.Repositories
{
    public interface IEntregadorRepository
    {
        Task<Entregador> ObterPorIdAsync(Guid id);
        Task<Entregador> ObterPorCnpjAsync(string cnpj);
        Task<Entregador> ObterPorNumeroCnhAsync(string numeroCnh);
        Task<IEnumerable<Entregador>> ObterTodosAsync();
        Task AdicionarAsync(Entregador entregador);
        Task AtualizarAsync(Entregador entregador);
        Task<bool> ExistePorCnpjAsync(string cnpj);
        Task<bool> ExistePorNumeroCnhAsync(string numeroCnh);
    }
}