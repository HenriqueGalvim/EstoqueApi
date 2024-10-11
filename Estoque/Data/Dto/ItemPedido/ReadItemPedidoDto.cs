namespace Estoque.Data.Dtos.ItemPedido;

public class ReadItemPedidoDto
{
	public int Id { get; set; }
	public int IdProduto { get; set; }

	public int? PedidoId { get; set; }
}
