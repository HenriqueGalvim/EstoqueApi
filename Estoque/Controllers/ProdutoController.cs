using AutoMapper;
using Estoque.Data;
using Estoque.Data.Dto.Produto;
using Estoque.Data.Dtos.ItemPedido;
using Estoque.Models;
using Estoque.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{

	private EstoqueDbContext _context;
	private IMapper _mapper;
	private EstoqueService _estoqueService;

	public ProdutoController(EstoqueDbContext context, IMapper mapper, EstoqueService estoqueService)
	{
		_context = context;
		_mapper = mapper;
		_estoqueService = estoqueService;
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public IActionResult AdicionaProduto([FromBody] CreateProdutoDto produtoDto)
	{
		var resultado = _estoqueService.AdicionaEstoque(produtoDto);
		return NoContent();
	}

	[HttpGet]
	public IEnumerable<ReadProdutoDto> ListarProdutos([FromQuery] int skip = 0, [FromQuery] int take = 50)
	{
		return _mapper.Map<List<ReadProdutoDto>>(_context.Produtos.Skip(skip).Take(take).ToList());
	}


	[HttpGet("{id}")]
	public IActionResult ListarProdutoPorId(int id)
	{
		var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);

		if (produto == null) return NotFound();

		var produtoDto = _mapper.Map<ReadProdutoDto>(produto);
		return Ok(produtoDto);
	}

	[HttpPut("{id}")]
	public ActionResult AtualizandoProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
	{
		var resultado = _estoqueService.AtualizandoEstoque(id, produtoDto);
		return NoContent();
	}


	[HttpPut("quantidade/{id}")]
	public async Task<ActionResult> AtualizandoQuantidadeProdutoEstoque(int id,[FromBody] int quantidade)
	{
		var resultado = _estoqueService.AtualizandoQuantidadeEstoque(id, quantidade);
        if (resultado == false)
        {
			return BadRequest("Erro, quantidade pedida é maior que a quantidade que há no estoque");
        }

		return NoContent();
    }

	[HttpDelete("{id}")]
	public ActionResult DeletarFilme(int id)
	{
		var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id)!;
		if (produto == null) return NotFound();

		_context.Remove(produto);
		_context.SaveChanges();
		return NoContent();
	}

	[HttpPost("teste")]
	public ActionResult ReceberItemPedido([FromBody] ReadItemPedidoDto readItemPedidoDto)
	{
        Console.WriteLine("Entrei na rota");
        return Ok(readItemPedidoDto);
	}
}
