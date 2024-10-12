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

        public async Task<Produto> AtualizarProduto(string id, Produto produto)
        {
           if(produto.QuantidadeEmEstoque < 0){
            throw new ArgumentException("A quantidade em estoque não pode ser negativa");
           }

            await _produtoRepository.AtualizarProdutoAsync(id, produto);
            return produto;

        }

        public async Task<List<Produto>> BuscaProdutos()
        {
            return await _produtoRepository.ObterProdutosAsync();
        }

        public async Task<Produto> BuscarProdutoPorId(string Id)
        {
            return await _produtoRepository.ObterProdutoPorId(Id);
        }

        public async Task<Produto> CriarProduto(Produto produto)
        {
            if(produto.QuantidadeEmEstoque < 0){
                throw new ArgumentException("A quantidade em estoque não pode ser negativa");
            }

            await _produtoRepository.CriarProdutoAsync(produto);
            return produto;

        }

        public async Task<bool> ExcluirProduto(string Id)
        {
            await _produtoRepository.ExcluirProdutoAsync(Id);
            return true;
        }
    }
}