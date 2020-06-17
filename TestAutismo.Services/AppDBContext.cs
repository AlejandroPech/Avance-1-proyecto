using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<Ninio> Ninios { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<CentroEducativo> CentroEducativos { get; set; }
    }
}
