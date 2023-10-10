using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MpCertificadoVrs2.Models
{
    public class CadastroPagamento
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdCartao { get; set; }
        public string NomeTitular { get; set; } = string.Empty;
        public string NumeroCartao { get; set; } = string.Empty;
        public string ValidadeCartao { get; set; } = string.Empty;
        public string CodigoSeguranca { get; set; } = string.Empty;
        public string EnderecoFaturamento { get; set; } = string.Empty;
        public string BancoEmissor { get; set; } = string.Empty;
        public string BandeiraCartao { get; set; } = string.Empty;
        public string CpfTitular { get; set; } = string.Empty;
        public string TelefoneTitular { get; set; } = string.Empty;

    }
}
//Arrumar chave estrangeira, carregar por Id do cliente

//Crud OK