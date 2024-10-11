using Estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data;

public class EstoqueDbContext : DbContext
{
	public EstoqueDbContext(DbContextOptions<EstoqueDbContext> opts) : base(opts)
	{

	}
	public DbSet<Produto> Produtos { get; set; }
}
