using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasRestApi.Domain.Models;

namespace VendasRestApi.Repository.interfaces
{
    public interface IProdutoRepository
    {
        public Task<List<Produto>> ObterProdutosAsync();
        public Task<Produto> ObterProdutoPorId(String Id);
        public Task<Produto> CriarProdutoAsync(Produto produto);
        public Task<Produto> AtualizarProdutoAsync(String Id, Produto produto);
        public Task<bool> ExcluirProdutoAsync(string Id);
    }
}