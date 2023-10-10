using MpCertificado.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MpCertificadoVrs2.Models
{
    public class Carrinho
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdCarrinho { get; set; }

        // Chave estrangeira referenciando a classe Cliente
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        // Chave estrangeira referenciando a classe CertificadoAnuncio
        public int CertificadoAnuncioId { get; set; }

        [ForeignKey("CertificadoAnuncioId")]
        public virtual CertificadoAnuncio CertificadoAnuncio { get; set; }
    }
}
//Classe Carrinho Carrega chaves estrangeiras de cliente e CertificadoAnuncio, Funcionou perfeitamente
//Deve carregar o valor dos produtos incluidos somalos e mostrar opções de parcelamento.