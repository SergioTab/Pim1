using Microsoft.EntityFrameworkCore;
using Pim1.Models;

namespace Pim1.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        {
        }
        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
