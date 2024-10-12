using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasRestApi.Domain.Models;
using VendasRestApi.Repository.interfaces;
using VendasRestApi.Service.interfaces;

namespace VendasRestApi.Service.impl
{
    public class VendaService : IVendaService
    {

        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoService _produtoService;

        public VendaService(IVendaRepository vendaRepository, IProdutoService produtoService)
        {
            _vendaRepository = vendaRepository;
            _produtoService = produtoService;
        }

        

        public Task<Venda> AtualizarVenda(string id, Venda venda)
        {
            throw new NotImplementedException();
        }

        public async Task<Venda> BuscarVendaPorId(string Id)
        {
            return await _vendaRepository.ObterVendaPorId(Id);
        }

        public async Task<List<Venda>> BuscaVendas()
        {
            return await _vendaRepository.ObterVendasAsync();
        }

        public async Task<Venda> CriarVenda(Venda venda)
        {
            foreach(var item in venda.Itens)
            {
                bool estoqueAtualizado = await _produtoService.AtualizaEstoque(item.ProductId, -item.Quantidade);

                if(!estoqueAtualizado){
                    throw new InvalidOperationException($"Não foi possível atualizar o estoque do produto {item.ProductId}");
                }

                await _vendaRepository.CriarVendaAsync(venda);
                return venda;
            }
        }

        public async Task<bool> ExcluirVenda(string Id)
        {
            var venda = await _vendaRepository.ObterVendaPorId(Id);

            if(venda == null){
                throw new InvalidOperationException("Venda não encontrado");
            }

            foreach (var item in venda.Itens)
            {
                await _produtoService.AtualizaEstoque(item.ProductId, item.Quantidade);
                
            }

            await _vendaRepository.CancelarVendaAsync(Id);
            return true;
        }
    }
}