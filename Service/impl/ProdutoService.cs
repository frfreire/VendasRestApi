using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnsClient.Protocol;
using VendasRestApi.Domain.Models;
using VendasRestApi.Repository.interfaces;
using VendasRestApi.Service.interfaces;

namespace VendasRestApi.Service.impl
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> AtualizaEstoque(string id, int quantidade)
        {
            var produto = await _produtoRepository.ObterProdutoPorId(id);

            if(produto == null){
                return false;
            } 

            int novoEstoque = produto.QuantidadeEmEstoque + quantidade;

            if(novoEstoque < 0){
                throw new Exception("Estoque insuficiente");
            }

            produto.QuantidadeEmEstoque = novoEstoque;
            await _produtoRepository.AtualizarProdutoAsync(id, produto);
            
            return true;
        }

        public Task<Produto> AtualizarProduto(string id, Produto produto)
        {
           throw new NotImplementedException();
        }

        public List<Task<Produto>> BuscaProdutos()
        {
            throw new NotImplementedException();
        }

        public Task<Produto> BuscarProdutoPorId(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> CriarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirProduto(string Id)
        {
            throw new NotImplementedException();
        }
    }
}