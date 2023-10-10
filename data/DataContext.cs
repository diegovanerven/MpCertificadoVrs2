using Microsoft.EntityFrameworkCore;
using MpCertificado.Models;
using MpCertificadoVrs2.Models;

namespace MpCertificadoVrs2.data

{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
        }

        // Monta associação no banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasDiscriminator<string>("TipoCliente")
                .HasValue<PessoaFisica>("PessoaFisica")
                .HasValue<PessoaJuridica>("PessoaJuridica");

            // Adiciona as entidades derivadas na hierarquia de herança
            modelBuilder.Entity<PessoaFisica>();
            modelBuilder.Entity<PessoaJuridica>();
        }

        public DbSet<CertificadoAnuncio> CertificadoAnuncios { get; set; }
        public DbSet<AcCertificadoraTeste> AcCertificadoraTestes { get; set; }
        public DbSet<CadastroPagamento> CadastroPagamentos { get; set; }
        public DbSet<CertificadoProduto> CertificadoProdutos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
    }
}


