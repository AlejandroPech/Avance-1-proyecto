using System;
using System.Collections.Generic;
using System.Text;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public class ContainerRepositoryPreguntas:IRepositoryPreguntas
    {
        private List<Pregunta> _Preguntas;

        public ContainerRepositoryPreguntas()
        {
            _Preguntas = new List<Pregunta>()
            {
                new Pregunta{PreguntaId=1,PreguntaRealizada="1. ¿Disfruta su hijo cuando se le balancea o se le hace saltar sobre sus rodillas?",Tipo=true},
                new Pregunta{PreguntaId=2,PreguntaRealizada="2. ¿Muestra interes por otros niños o niñas?",Tipo=false},
                new Pregunta{PreguntaId=3,PreguntaRealizada="3. ¿Le gusta subirse a las cosas como sillones, escaloness, juegos del parque?",Tipo=true},
                new Pregunta{PreguntaId=4,PreguntaRealizada="4. ¿Le gusta que el adulto juegue con él o ella al 'Cucu-Tras'(Taparse los ojos y luego descubrirlos:jugar a esconderse y aparecer de repente)?",Tipo=true},
                new Pregunta{PreguntaId=5,PreguntaRealizada="5. ¿Hace juegos, como si habla por telefono, como si estuviera dando de comer auna muñeca, o si estuviera condicoendo un coche?",Tipo=true},
                new Pregunta{PreguntaId=6,PreguntaRealizada="6. ¿Suele señalar con el dedo para pedir algo?",Tipo=true},
                new Pregunta{PreguntaId=7,PreguntaRealizada="7. ¿Suele señalar con el dedo para indicar que algo le llama la atención",Tipo=false},
                new Pregunta{PreguntaId=8,PreguntaRealizada="8. ¿Puede jugar adecuadamente con piezas o juguetes pequeños(Por ejemplo cochesitos, muñequitos o bloque de construcción),sin unicamente chuparlos,agitarlos o tirarlos?",Tipo=true},
                new Pregunta{PreguntaId=9,PreguntaRealizada="9. ¿Suele traer objetos para enseñarselo?",Tipo=false},
                new Pregunta{PreguntaId=10,PreguntaRealizada="10. ¿Suele mirarle a los ojos durante algunos segundos",Tipo=true},
                new Pregunta{PreguntaId=11,PreguntaRealizada="11. ¿Le parece demaciado sensible a ruidos poco intensos? (Por ejemplo, reacciona tapandose los oidos o le genera alguna angustia)",Tipo=true},
                new Pregunta{PreguntaId=12,PreguntaRealizada="12. ¿Sonrie al verle a usted o cuando usted le sonrie?",Tipo=true},
                new Pregunta{PreguntaId=13,PreguntaRealizada="13. ¿Puede imitar o repetir acciones que usted hace?(Por ejemplo, si usted hace una mueca él o ella tambien lo hace)",Tipo=false},
                new Pregunta{PreguntaId=14,PreguntaRealizada="14. ¿Responde cuando se le llama por su nombre?",Tipo=false},
                new Pregunta{PreguntaId=15,PreguntaRealizada="15. Si usted señala con el dedo al otro lado de la habitación. ¿dirige su hijo o hija la mirada hacia ese juguete",Tipo=false},
                new Pregunta{PreguntaId=16,PreguntaRealizada="16. ¿Ha aprendido ya a caminar?",Tipo=true},
                new Pregunta{PreguntaId=17,PreguntaRealizada="17. Si usted esta mirando algo atentamente.¿Su hijo a su hija se pone tambien a mirarlo?",Tipo=true},
                new Pregunta{PreguntaId=18,PreguntaRealizada="18. ¿Hace su hijo o hija movimientos raros con los dedos,por ejemplo acercandoselo a los hojos",Tipo=true},
                new Pregunta{PreguntaId=19,PreguntaRealizada="19. ¿Intenta que usted le preste atención preste atencion a las actividades que él o ella esta haciendo?",Tipo=true},
                new Pregunta{PreguntaId=20,PreguntaRealizada="20. ¿Alguna vez ha pensado que su hijo o hija podria tener sordera?",Tipo=true},
                new Pregunta{PreguntaId=21,PreguntaRealizada="21. ¿Entiende su hijo o hija lo que la gente le dice?",Tipo=true},
                new Pregunta{PreguntaId=22,PreguntaRealizada="22. ¿Se queda mirando al vacio o ve de un lado a otro sin razon?",Tipo=true},
                new Pregunta{PreguntaId=23,PreguntaRealizada="23. ¿Su hijo o hija tiene que enfrentarse auna situación desconocida. ¿Le mira primero a usted a la cara para saber como reaccionar?",Tipo=true}
            };            
        }

        public IEnumerable<Pregunta> GetPreguntas()
        {
            return _Preguntas;
        }
    }
}
