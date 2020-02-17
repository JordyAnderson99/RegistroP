using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RegistroP.Entidades;

namespace RegistroP.DAL
{
    class Contexto: DbContext
    {
        public DbSet<Persona> Persona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; DataBase = TestDb; Trunted_Conneion= true");
        }

    }
}
