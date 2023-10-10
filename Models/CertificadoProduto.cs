using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MpCertificadoVrs2.Models
{
    public class CertificadoProduto
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdCertificadoP { get; set; }
        public string CnpjAc { get; set; } = string.Empty;
        public string DocumentoCliente { get; set; } = string.Empty;
        public string NumeroSerie { get; set; } = string.Empty;
        public string Criptografia { get; set; } = string.Empty;
        public string Linguagem { get; set; } = string.Empty;
        public string TipoDispositivo { get; set; } = string.Empty;
        public string TipoCertificado { get; set; } = string.Empty;
        public string ValidacaoVideo { get; set; } = string.Empty; //remover virou uma tabela
        public string CodidoRastreio { get; set; } = string.Empty;
    }
}
//teste Crud ok