using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using VendasRestApi.Domain.Models;
using VendasRestApi.Repository.interfaces;

namespace VendasRestApi.Repository.impl
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IMongoCollection<Produto> _produtos;

        public ProdutoRepository(IMongoDatabase database)
        {
            _produtos = database.GetCollection<Produto>("Produtos");
        }

        public async Task<Produto> AtualizarProdutoAsync(string Id, Produto produto)
        {
            await _produtos.ReplaceOneAsync(p => p.Id == Id, produto);
            return produto;
        }

        public async Task<Produto> CriarProdutoAsync(Produto produto)
        {
            await _produtos.InsertOneAsync(produto);
            return produto;
        }

        public async Task<bool> ExcluirProdutoAsync(string Id)
        {
            await _produtos.DeleteOneAsync(p => p.Id == Id);
            return true;
        }

        public async Task<Produto> ObterProdutoPorId(string Id)
        {
            return await _produtos.Find(p => p.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Produto>> ObterProdutosAsync()
        {
            return await _produtos.Find(_ => true).ToListAsync();
        }
    }
}