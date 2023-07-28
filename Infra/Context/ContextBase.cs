using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions options) : base(options)
        {
        }
             
        public DbSet<SistemaFinanceiro> SistemaFinanceiros { set; get; }
        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiros { set; get; }
        public DbSet<Categoria> Categorias { set; get; }
        public DbSet<Despesa> Despesas { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("Asp.NetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Data Source=localhost\\SQLEXPRESS01; Initial Catalog=BaseFinanceiro;;Integrated Security=False;User ID=sa;Password=fdas*2018;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }
    }
}
