using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasRestApi.Domain.Models;

namespace VendasRestApi.Service.impl
{
    public interface IVendaService
    {
        public Task<Venda> CriarVenda(Venda venda);
        public Task<Venda> AtualizarVenda(string id, Venda venda);
        public Task<bool> ExcluirVenda(string Id);
        public Task<List<Venda>> BuscaVendas();
        public Task<Venda> BuscarVendaPorId(string Id);
    }
}