using MpCertificadoVrs2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MpCertificadoVrs2.Models
{
    public class Cliente
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Endereco { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;

        // Transforma Cliente , PessoaFisica e PessoaJuridica em uma associação no banco de dados 
        // descobrir como deixar padrão no preenchimento
        public string TipoCliente { get; set; } 

        // Propriedade de navegação para os Carrinhos
        //public virtual ICollection<Carrinho> Carrinhos { get; set; }
    }
}
//Super classe Cliente, possui PessoaFisica e PessoaJuridica como Herdeiros, todos os Ids criados se juntam em uma unica tabela
