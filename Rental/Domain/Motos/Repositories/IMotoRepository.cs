using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuRental.Domain.Motos.Entities;

namespace MottuRental.Domain.Motos.Repositories
{
    public interface IMotoRepository
    {
        Task<Moto> ObterPorIdAsync(Guid id);
        Task<Moto> ObterPorPlacaAsync(string placa);
        Task<IEnumerable<Moto>> ObterTodasAsync();
        Task<IEnumerable<Moto>> FiltrarPorPlacaAsync(string placa);
        Task AdicionarAsync(Moto moto);
        Task AtualizarAsync(Moto moto);
        Task RemoverAsync(Moto moto);
        Task<bool> ExisteLocacaoParaMotoAsync(Guid motoId);
    }
}