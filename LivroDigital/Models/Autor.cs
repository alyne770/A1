using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LivroDigital.Models
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "O nome do autor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do autor deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida.")]
        [DisplayName("Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        [StringLength(50, ErrorMessage = "A nacionalidade deve ter no máximo 50 caracteres.")]
        public string Nacionalidade { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}