
using MpCertificadoVrs2.Metodos;

namespace MpCertificadoVrs2.Models
{
    public class PessoaFisica : Cliente
    {
        private string _cpf = string.Empty;
        public string Cpf
        {
            get => _cpf;
            set
            {
                // Remova espaços em branco antes e depois do CPF
                _cpf = value?.Trim();
            }
        }

        public string Nome { get; set; } = string.Empty;
        public string Idade { get; set; } = string.Empty;
        public string Profissao { get; set; } = string.Empty;

       
        // Metodo deve impedir CPF repetido
        // Adicione um método para validar o CPF
        public bool IsValidCpf()
        {
            return CpfValidator.IsValidCpf(Cpf);
        }
    }
}
