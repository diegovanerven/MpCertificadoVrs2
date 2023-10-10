using MpCertificadoVrs2.Metodos;

namespace MpCertificadoVrs2.Models
{
    public class PessoaJuridica : Cliente
    {
        private string _cnpj = string.Empty;

        [CnpjValidation] // Aplicando o atributo de validação
        public string Cnpj
        {
            get => _cnpj;
            set
            {
                // Remova espaços em branco antes e depois do CNPJ
                _cnpj = value?.Trim();
            }
        }

        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;

        // Adicione este método para validar o CNPJ
        public bool IsValidCnpj()
        {
            return CnpjValidation.IsValidCnpj(Cnpj);
        }
    }
}
