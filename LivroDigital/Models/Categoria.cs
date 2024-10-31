using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LivroDigital.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da categoria deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}