using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaAsp.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El apellido debe tener entre 3 y 100 caracteres.")]
        [Display(Name = "Apellido")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? DateOfBirth { get; set; }

        // Navegación 1‑N: un autor puede tener muchos libros
        public ICollection<Book>? Books { get; set; }
        [NotMapped]
        public string FullName => $"{Name} {Surname}";
    }
}
