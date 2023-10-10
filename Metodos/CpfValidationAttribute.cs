using System;
using System.ComponentModel.DataAnnotations;

using MpCertificadoVrs2.Metodos;

namespace MpCertificado.Models.Metodos
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class CpfValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return new ValidationResult("O CPF é obrigatório.");
            }

            if (value is not string cpf)
            {
                return new ValidationResult("O valor fornecido não é uma string.");
            }

            if (string.IsNullOrEmpty(cpf))
            {
                return new ValidationResult("O CPF é obrigatório.");
            }

            if (!CpfValidator.IsValidCpf(cpf))
            {
                return new ValidationResult("CPF inválido.");
            }

            return ValidationResult.Success;
        }
    }
}