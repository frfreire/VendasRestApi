using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using VendasRestApi.Domain.Models;
using VendasRestApi.Repository.interfaces;

namespace VendasRestApi.Repository.impl
{
    public class VendaRepository : IVendaRepository
    {
        private readonly IMongoCollection<Venda> _vendas;

        public VendaRepository(IMongoDatabase database)
        {
            _vendas = database.GetCollection<Venda>("Vendas");
        }
        public async Task<Venda> AtualizarVendaAsync(string Id, Venda venda)
        {
            await _vendas.ReplaceOneAsync(v => v.Id == Id, venda);
            return venda;
        }

        public async Task<Venda> CriarVendaAsync(Venda venda)
        {
            await _vendas.InsertOneAsync(venda);
            return venda;
        }

        public async Task<bool> CancelarVendaAsync(string Id)
        {
            await _vendas.DeleteOneAsync(v => v.Id == Id);
            return true;
        }

        public async Task<Venda> ObterVendaPorId(string Id)
        {
            return await _vendas.Find(v => v.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Venda>> ObterVendasAsync()
        {
            return await _vendas.Find(_ => true).ToListAsync();
        }
    }
}