using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroP.Entidades
{
    public class Persona
    {   [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int PersonaId { get; set; }
        public string Comentario { get; set; }
        public int Monto { get; set; }
        public int Balance { get; set; }
        

        public Persona()
        {
            Id = 0;
            Fecha = DateTime.Now;
            PersonaId = 0;
            Comentario = string.Empty;
            Monto = 0;
            Balance= 0;
                     

        }
    }

    
}
