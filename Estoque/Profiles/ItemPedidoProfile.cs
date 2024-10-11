using AutoMapper;
using Estoque.Data.Dtos.ItemPedido;
using Estoque.Models;

namespace Estoque.Profiles;

public class ItemPedidoProfile : Profile
{
    public ItemPedidoProfile()
    {
/*		CreateMap<CreateItemPedidoDto, Produto>();*/
/*		CreateMap<UpdateItemPedidoDto, Produto>();*/
/*		CreateMap<Produto, UpdateItemPedidoDto>();*/
		CreateMap<ItemPedido, ReadItemPedidoDto>();
	}
}
