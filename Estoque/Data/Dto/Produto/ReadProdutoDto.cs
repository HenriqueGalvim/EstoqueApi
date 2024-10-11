using System.ComponentModel.DataAnnotations;

namespace Estoque.Data.Dto.Produto;

public class ReadProdutoDto
{
	[Key]
	[Required]
	public int Id { get; set; }

	[Required]
	public string Nome { get; set; }

	[Required]
	public string Descricao { get; set; }

	[Required]
	public float PrecoUnitario { get; set; }

	[Required]
	public int Quantidade { get; set; }

}
