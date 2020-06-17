using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAutismo.Models
{
    public class Tutor:BaseEntity
    {
        [Required(ErrorMessage = "Llenar el compo del Nombre")]
        [Display(Name ="Nombre",Prompt ="Nombre")]
        public string NombreTutor { get; set; }
        [Required(ErrorMessage = "Llenar el compo de los apellidos")]
        [Display(Name="Apellidos",Prompt ="Apellidos")]
        public string ApellidosTutor { get; set; }        
        public string FullName { get { return $"{NombreTutor} {ApellidosTutor}".Trim(); } }
        [Display(Name ="Curp",Prompt ="Curp")]
        public string CurpTutor { get; set; }
        [Display(Name ="Fecha de Na.",Prompt ="Fecha de Na.")]
        public DateTime FechaNacimientoT { get; set; }        
        [Display(Name ="Direccion",Prompt ="Direccion")]
        public string DireccionT { get; set; }        
        public Cuenta Cuenta { get; set; }
        [Required(ErrorMessage = "Correo Electronico Requerido")]
        [Display(Name ="Correo")]
        [ForeignKey("Cuenta")]
        public int CuentaId { get; set; }
        [Display(Name ="Nacionalidad",Prompt ="Nacionalidad")]
        public Nacionalidad NacionalidadT { get; set; }
        public ICollection<Ninio> Ninios { get; set; }        
    }
}
