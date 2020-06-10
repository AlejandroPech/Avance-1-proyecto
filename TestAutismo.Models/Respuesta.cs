using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutismo.Models
{
    public class Respuesta
    {
        public int RespuestaId { get; set; }
        public bool ValorRespuesta { get; set; }
        public int NinioId { get; set; }
        public Ninio Ninio { get; set; }

    }
}
