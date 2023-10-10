namespace MpCertificadoVrs2.Metodos
{
    public static class CpfValidator
    {
        public static bool IsValidCpf(string cpf)
        {
            // Remova caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
            {
                return false;
            }

            // Verifica se todos os dígitos são iguais (ex: 111.111.111-11)
            if (cpf.All(digit => digit == cpf[0]))
            {
                return false;
            }

            // Calcula o primeiro dígito verificador
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (10 - i);
            }

            int remainder = sum % 11;
            int digit1 = remainder < 2 ? 0 : 11 - remainder;

            // Verifica o primeiro dígito verificador
            if (int.Parse(cpf[9].ToString()) != digit1)
            {
                return false;
            }

            // Calcula o segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (11 - i);
            }

            remainder = sum % 11;
            int digit2 = remainder < 2 ? 0 : 11 - remainder;

            // Verifica o segundo dígito verificador
            return int.Parse(cpf[10].ToString()) == digit2;
        }
    }
}
