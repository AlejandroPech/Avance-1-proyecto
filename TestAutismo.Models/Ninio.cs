using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAutismo.Models
{
    public class Ninio: BaseEntity
    {
        [Required(ErrorMessage = "Nombre del niño requerido")]
        [Display(Name = "Nombre", Prompt = "Nombre")]
        public string NombreNinio { get; set; }
        [Required(ErrorMessage = "Apellidos del niño requerido")]
        [Display(Name = "Apellidos", Prompt = "Apellidos")]
        public string ApellidosNinio { get; set; }
        public string NombreCompletoNiño { get {return $"{NombreNinio} {ApellidosNinio}".Trim(); }}
        [Display(Name = "Curp", Prompt = "Curp")]
        public string CurpNinio { get; set; }
        
        [Display(Name = "Nacionalidad", Prompt = "Nacionalidad")]
        public Nacionalidad Nacionalidad { get; set; }
        [Display(Name = "Direccion", Prompt = "Direccion")]
        public string  Direccion { get; set; }
        [Display(Name = "Fecha de Na.", Prompt = "Fecha de Na.")]
        public DateTime FechaNacimientoN { get; set; }
        public string Fotografia { get; set; }
        [Required(ErrorMessage = "Tutor requerido")]
        [Display(Name = "Tutor")]
        [ForeignKey("Tutor")]
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }
        [Required(ErrorMessage = "Centro Educativo Requerido")]
        [Display(Name = "Centro Educativi")]
        [ForeignKey("CentroEducativo")]
        public int CentroEducativoId { get; set; }
        public CentroEducativo CentroEducativo { get; set; }
        
    }
}
