using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestAutismo.Models
{
    public class Tutor
    {
        public int TutorId { get; set; }
        [Display(Name ="Nombre",Prompt ="Nombre")]
        public string NombreTutor { get; set; }
        [Display(Name="Apellidos",Prompt ="Apellidos")]
        public string ApellidosTutor { get; set; }        
        public string FullName { get { return $"{NombreTutor} {ApellidosTutor}".Trim(); } }
        [Display(Name ="Curp",Prompt ="Curp")]
        public string CurpTutor { get; set; }
        [Display(Name ="Fecha de Na.",Prompt ="Fecha de Na.")]
        public DateTime FechaNacimientoT { get; set; }
        [Display(Name ="Genero")]
        public bool GeneroT { get; set; }
        [Display(Name ="Direccion",Prompt ="Direccion")]
        public string DireccionT { get; set; }
        [Display(Prompt ="Contraseña")]
        public string Contraseña { get; set; }
        public Cuenta Cuenta { get; set; }
        [Display(Name ="Correo",Prompt ="Correo")]
        public int CuentaId { get; set; }
        [Display(Name ="Nacionalidad",Prompt ="Nacionalidad")]
        public Nacionalidad NacionalidadT { get; set; }
        public ICollection<Ninio> Ninio { get; set; }        
    }
}
