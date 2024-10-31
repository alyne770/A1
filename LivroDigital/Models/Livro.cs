using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace LivroDigital.Models
{
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(200, ErrorMessage = "O título deve ter no máximo 200 caracteres.")]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O ano de publicação é obrigatório.")]
        [Range(1500, 2100, ErrorMessage = "O ano de publicação deve ser entre 1500 e o ano atual.")]
        [DisplayName("Ano de Publicação")]
        public int AnoPublicacao { get; set; }

        [Required(ErrorMessage = "O ISBN é obrigatório.")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "O ISBN deve ter entre 10 e 13 caracteres.")]
        [Index(IsUnique = true)]
        public string ISBN { get; set; }

        [Required]
        [DisplayName("Editora")]
        public int EditoraId { get; set; }
        public virtual Editora Editora { get; set; }

        public virtual ICollection<Autor> Autores { get; set; }
        public virtual ICollection<Categoria> Categorias { get; set; }
        public List<int> CategoriaIds { get; set; }
        public List<Categoria> CategoriasDisponiveis { get; set; } = new List<Categoria>();
        public List<int> AutorIds { get; set; }
        public List<Autor> AutoresDisponiveis { get; set; } = new List<Autor>();
    }
}