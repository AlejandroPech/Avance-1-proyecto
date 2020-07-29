using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAutismo.Models
{
    public class Ninio: BaseEntity
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "El nombre debe empezar con mayusculas sin caractéres especiales")]
        [Required(ErrorMessage = "Nombre del niño es un campo requerido")]
        [Display(Name = "Nombre", Prompt = "Nombre")]
        public string NombreNinio { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "El apellido debe empezar con mayusculas sin caractéres especiales")]
        [Required(ErrorMessage = "Apellidos del niño es un campo requerido")]
        [Display(Name = "Apellidos", Prompt = "Apellidos")]
        public string ApellidosNinio { get; set; }
        public string NombreCompletoNiño { get {return $"{NombreNinio} {ApellidosNinio}".Trim(); }}
        [Display(Name = "Curp", Prompt = "Curp")]
        public string CurpNinio { get; set; }
        
        [Display(Name = "Nacionalidad", Prompt = "Nacionalidad")]
        public Nacionalidad Nacionalidad { get; set; }
        [Display(Name = "Direccion", Prompt = "Direccion")]
        public string  Direccion { get; set; }
        [Required(ErrorMessage = "Fecha de Nacimiento es un campo requerido")]
        [Display(Name = "Fecha de Na.", Prompt = "Fecha de Na.")]
        public DateTime FechaNacimientoN { get; set; }
        public string Fotografia { get; set; }
        [Required(ErrorMessage = "Tutor requerido")]
        [Display(Name = "Tutor")]
        [ForeignKey("Tutor")]
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }
        [Required(ErrorMessage = "Centro Educativo Requerido")]
        [Display(Name = "Centro Educativo")]
        [ForeignKey("CentroEducativo")]
        public int CentroEducativoId { get; set; }
        public CentroEducativo CentroEducativo { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }

    }
}
