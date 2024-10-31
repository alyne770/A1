using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LivroDigital.Models
{
    public class Emprestimo
    {
        [Key]
        public int EmprestimoId { get; set; }

        [Required]
        [DisplayName("Livro")]
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }

        [Required]
        [DisplayName("Usuário")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Required(ErrorMessage = "A data de empréstimo é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayName("Data de Empréstimo")]
        public DateTime DataEmprestimo { get; set; }

        [DataType(DataType.Date)]
        [CustomValidation(typeof(Emprestimo), "ValidarDataDevolucao")]
        [DisplayName("Data de Devolução")]
        public DateTime? DataDevolucao { get; set; }

        public static ValidationResult ValidarDataDevolucao(DateTime? dataDevolucao, ValidationContext context)
        {
            var instance = context.ObjectInstance as Emprestimo;
            if (dataDevolucao.HasValue && instance != null && dataDevolucao < instance.DataEmprestimo)
            {
                return new ValidationResult("A data de devolução não pode ser anterior à data de empréstimo.");
            }
            return ValidationResult.Success;
        }
    }
}