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
        public string Nombre { get; set; }
        public string Comentario { get; set; }
        public decimal Monto { get; set; }
        public decimal Pago { get; set; }
        public decimal Balance { get; set; }

        public Persona()
        {
            Id = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            Comentario = string.Empty;
            Monto = 0;
            Pago = 0;
            Balance = 0;
        }

        public Persona(int id, DateTime fecha, string nombre, string comentario, decimal monto, decimal pago, decimal balance)
        {
            Id = id;
            Fecha = fecha;
            Nombre = nombre;
            Comentario = comentario;
            Monto = monto;
            Pago = pago;
            Balance = balance;
        }

        
    }

    
}
