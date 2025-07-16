using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAsp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(200, ErrorMessage = "El título no puede exceder 200 caracteres.")]
        [Display(Name = "Título")]
        public string Title { get; set; }
        [Required(ErrorMessage = "El resumen es obligatorio.")]
        [StringLength(1000, ErrorMessage = "El resumen no puede exceder 1000 caracteres.")]
        [Display(Name = "Resumen")]
        public string Summary { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de publicacion")]
        public DateTime PublicationDate { get; set; }

        // Clave foránea y navegación a Author
        [Display(Name = "Autor/a")]
        [Required(ErrorMessage = "Debes seleccionar a un autor/a.")]
        public int AuthorId { get; set; }
        [Display(Name ="Autor/a")]
        public Author? Author { get; set; }
    }
}
