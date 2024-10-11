using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Models;

public class ItemPedido
{
	[Key]
	[Required]
	public int Id { get; set; }

	[Required]
	public int IdProduto { get; set; }

	[ForeignKey("Id")]
	public int? PedidoId { get; set; }

}
