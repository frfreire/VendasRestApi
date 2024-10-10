using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasRestApi.Domain.Models;

namespace VendasRestApi.Repository.interfaces
{
    public interface IVendaRepository
    {
        public Task<List<Venda>> ObterVendasAsync();
        public Task<Venda> ObterVendaPorId(String Id);
        public Task<Venda> CriarVendaAsync(Venda venda);
        public Task<Venda> AtualizarVendaAsync(String Id, Venda venda);
        public Task<bool> ExcluirProdutoAsync(string Id);
    }
}