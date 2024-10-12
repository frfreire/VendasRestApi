using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasRestApi.Domain.Models;
using VendasRestApi.Service.interfaces;

namespace VendasRestApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetAllProducts()
        {
            var produtos = await _produtoService.BuscaProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProductById(string Id){
            var produto = await _produtoService.BuscarProdutoPorId(Id);
            return Ok(produto);

        }

        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProduct(Produto produto)
        {
            await _produtoService.CriarProduto(produto);

            return CreatedAtAction(nameof(GetProductById), new { produto.Id }, produto);    
        }

        [HttpPut]
        public async Task<ActionResult<Produto>> EditProduct(string Id, Produto produto)
        {
            await _produtoService.AtualizarProduto(Id, produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(string Id)
        {
            await _produtoService.ExcluirProduto(Id);
            return NoContent();
        }
    }
}