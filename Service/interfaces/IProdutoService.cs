using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasRestApi.Domain.Models;

namespace VendasRestApi.Service.interfaces
{
    public interface IProdutoService
    {
        public Task<Produto> CriarProduto(Produto produto);
        public Task<Produto> AtualizarProduto(string id, Produto produto);
        public Task<bool> ExcluirProduto(string Id);
        public Task<List<Produto>> BuscaProdutos();
        public Task<Produto> BuscarProdutoPorId(string Id);
        public Task<bool> AtualizaEstoque(string id, int quantidade);
    }
}