using System;
using System.ComponentModel.DataAnnotations;

using MpCertificadoVrs2.Metodos;

namespace MpCertificadoVrs2.Metodos
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class CnpjValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return new ValidationResult("O CNPJ é obrigatório.");
            }

            if (value is not string cnpj)
            {
                return new ValidationResult("O valor fornecido não é uma string.");
            }

            if (string.IsNullOrEmpty(cnpj))
            {
                return new ValidationResult("O CNPJ é obrigatório.");
            }

            if (!CnpjValidation.IsValidCnpj(cnpj))
            {
                return new ValidationResult("CNPJ inválido.");
            }

            return ValidationResult.Success;
        }
    }
}
