using System;
using System.Linq;

namespace MpCertificadoVrs2.Metodos
{
    public static class CnpjValidation
    {
        public static bool IsValidCnpj(string cnpj)
        {
            // Remove caracteres não numéricos
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            // Verifica se o CNPJ tem 14 dígitos
            if (cnpj.Length != 14)
            {
                return false;
            }

            // Verifica se todos os dígitos são iguais (ex: 00.000.000/0000-00)
            if (cnpj.All(digit => digit == cnpj[0]))
            {
                return false;
            }

            // Calcula o primeiro dígito verificador
            int[] weights1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(cnpj[i].ToString()) * weights1[i];
            }

            int remainder1 = sum % 11;
            int digit13 = remainder1 < 2 ? 0 : 11 - remainder1;

            // Verifica o primeiro dígito verificador
            if (int.Parse(cnpj[12].ToString()) != digit13)
            {
                return false;
            }

            // Calcula o segundo dígito verificador
            int[] weights2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = 0;
            for (int i = 0; i < 13; i++)
            {
                sum += int.Parse(cnpj[i].ToString()) * weights2[i];
            }

            int remainder2 = sum % 11;
            int digit14 = remainder2 < 2 ? 0 : 11 - remainder2;

            // Verifica o segundo dígito verificador
            return int.Parse(cnpj[13].ToString()) == digit14;
        }
    }

}
