using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LivroDigital.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do usuário deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Telefone inválido.")]
        [RegularExpression(@"^\(\d{2}\)\d{5}-\d{4}$", ErrorMessage = "O Telefone deve estar no formato (99)99999-9999.")]
        public string Telefone { get; set; }

        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
    }
}