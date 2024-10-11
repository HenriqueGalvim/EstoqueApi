using AutoMapper;
using Estoque.Data;
using Estoque.Data.Dto.Produto;
using Estoque.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Services;

public class EstoqueService : ControllerBase
{
	private EstoqueDbContext _context;
	private IMapper _mapper;
	public EstoqueService(EstoqueDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public async Task AdicionaEstoque (CreateProdutoDto produtoDto)
	{
		Produto produto = _mapper.Map<Produto>(produtoDto);
		_context.Produtos.Add(produto);
		_context.SaveChanges();
	}

	public async Task AtualizandoEstoque(int id, UpdateProdutoDto produtoDto)
	{
		var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id)!;
		_mapper.Map(produtoDto, produto);
		_context.SaveChanges();
	}

	public bool AtualizandoQuantidadeEstoque(int id, int quantidade)
	{
		var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id)!;
        if (quantidade > produto.Quantidade )
        {
            Console.WriteLine("Erro");
            return false;
        }
        Console.WriteLine("Estou aqui");
        produto.Quantidade -= quantidade;
		_context.SaveChanges();

		return true;
    }
}
