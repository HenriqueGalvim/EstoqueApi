using AutoMapper;
using Estoque.Models;
using Estoque.Data.Dto.Produto;

namespace Estoque.Profiles;

public class ProdutoProfile : Profile
{
	public ProdutoProfile()
	{
		CreateMap<CreateProdutoDto, Produto>();
		CreateMap<UpdateProdutoDto, Produto>();
		CreateMap<Produto, UpdateProdutoDto>();
		CreateMap<Produto, ReadProdutoDto>();

	}
}
