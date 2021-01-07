using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormsExamples.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Entre 3 e 60 caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Formato inválido")]
        [Required(ErrorMessage = "Obrigatório")]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataDeLancamento { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$", ErrorMessage = "Formato inválido")]
        [Display(Name = "Gênero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [Range(1, 1000, ErrorMessage = "Entre 1 e 1000")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [RegularExpression(@"^[0-5]*$", ErrorMessage = "Somente números entre 0 e 5")]
        [Display(Name = "Avaliação")]
        public int Avaliacao { get; set; }
    }
}
