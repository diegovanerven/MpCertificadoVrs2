

//acrescentar tipo certificado A1 e A3 Rever isso em todas as etapas do crud

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MpCertificadoVrs2.Models;

namespace MpCertificadoVrs2.Models
{
    public class CertificadoAnuncio
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdCertificadoA { get; set; }
        public string TipoDeCliente { get; set; } = string.Empty;
        public string TipoDeDispositivo { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
        public int IdFabricante { get; set; }
        public string TempoDeValidade { get; set; } = string.Empty;
        public string TipoDeEmissao { get; set; } = string.Empty;
        public float Valor { get; set; }

        // Coleção de carrinhos associados a este certificado
       // public virtual ICollection<Carrinho> Carrinhos { get; set; }
    }
}
//Teste Crud OK
// Melhoria: Carregar id Fabricante como chave estrangeira