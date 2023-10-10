using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MpCertificadoVrs2.Migrations
{
    /// <inheritdoc />
    public partial class vrs2Ed01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcCertificadoraTestes",
                columns: table => new
                {
                    IdCertificadora = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCertificadora = table.Column<string>(type: "TEXT", nullable: false),
                    CNPJ = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroInmetro = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcCertificadoraTestes", x => x.IdCertificadora);
                });

            migrationBuilder.CreateTable(
                name: "CadastroPagamentos",
                columns: table => new
                {
                    IdCartao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeTitular = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroCartao = table.Column<int>(type: "INTEGER", nullable: false),
                    ValidadeCartao = table.Column<int>(type: "INTEGER", nullable: false),
                    CodigoSeguranca = table.Column<int>(type: "INTEGER", nullable: false),
                    EnderecoFaturamento = table.Column<string>(type: "TEXT", nullable: false),
                    BancoEmissor = table.Column<string>(type: "TEXT", nullable: false),
                    BandeiraCartao = table.Column<string>(type: "TEXT", nullable: false),
                    CpfTitular = table.Column<int>(type: "INTEGER", nullable: false),
                    TelefoneTitular = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroPagamentos", x => x.IdCartao);
                });

            migrationBuilder.CreateTable(
                name: "CertificadoAnuncios",
                columns: table => new
                {
                    IdCertificadoA = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoDeCliente = table.Column<string>(type: "TEXT", nullable: false),
                    TipoDeDispositivo = table.Column<string>(type: "TEXT", nullable: false),
                    Fabricante = table.Column<string>(type: "TEXT", nullable: false),
                    IdFabricante = table.Column<int>(type: "INTEGER", nullable: false),
                    TempoDeValidade = table.Column<string>(type: "TEXT", nullable: false),
                    TipoDeEmissao = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificadoAnuncios", x => x.IdCertificadoA);
                });

            migrationBuilder.CreateTable(
                name: "CertificadoProdutos",
                columns: table => new
                {
                    IdCertificadoP = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CnpjAc = table.Column<string>(type: "TEXT", nullable: false),
                    DocumentoCliente = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroSerie = table.Column<string>(type: "TEXT", nullable: false),
                    Criptografia = table.Column<string>(type: "TEXT", nullable: false),
                    Linguagem = table.Column<string>(type: "TEXT", nullable: false),
                    TipoDispositivo = table.Column<string>(type: "TEXT", nullable: false),
                    TipoCertificado = table.Column<string>(type: "TEXT", nullable: false),
                    ValidacaoVideo = table.Column<string>(type: "TEXT", nullable: false),
                    CodidoRastreio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificadoProdutos", x => x.IdCertificadoP);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Endereco = table.Column<string>(type: "TEXT", nullable: false),
                    Cep = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Celular = table.Column<string>(type: "TEXT", nullable: false),
                    TipoCliente = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Idade = table.Column<string>(type: "TEXT", nullable: true),
                    Profissao = table.Column<string>(type: "TEXT", nullable: true),
                    Cnpj = table.Column<string>(type: "TEXT", nullable: true),
                    RazaoSocial = table.Column<string>(type: "TEXT", nullable: true),
                    NomeFantasia = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    IdCarrinho = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    CertificadoAnuncioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.IdCarrinho);
                    table.ForeignKey(
                        name: "FK_Carrinhos_CertificadoAnuncios_CertificadoAnuncioId",
                        column: x => x.CertificadoAnuncioId,
                        principalTable: "CertificadoAnuncios",
                        principalColumn: "IdCertificadoA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrinhos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_CertificadoAnuncioId",
                table: "Carrinhos",
                column: "CertificadoAnuncioId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_ClienteId",
                table: "Carrinhos",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcCertificadoraTestes");

            migrationBuilder.DropTable(
                name: "CadastroPagamentos");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "CertificadoProdutos");

            migrationBuilder.DropTable(
                name: "CertificadoAnuncios");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
