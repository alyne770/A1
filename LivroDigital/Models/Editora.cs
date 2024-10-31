using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LivroDigital.Models
{
    public class Editora
    {
        [Key]
        public int EditoraId { get; set; }

        [Required(ErrorMessage = "O nome da editora é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da editora deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [StringLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres.")]
        public string Cidade { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}