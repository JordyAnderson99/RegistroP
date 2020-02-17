using System;
using System.Collections.Generic;
using System.Text;
using RegistroP.DAL;
using RegistroP.Entidades;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroP.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Persona.Add(persona) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        } 

        public static bool Modificar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(persona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = db.SaveChanges()>0 ;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Persona.Find(id);
                db.Entry(eliminar).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static  Persona Buscar(int id)
        {
            Contexto db = new Contexto();
            Persona persona = new Persona();
            try
            {
                persona = db.Persona.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return persona;
        }

        public static List<Persona> GetList(Expression<Func<Persona, bool>> persona)
        {
            List<Persona> Lista = new List<Persona>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Persona.Where(persona).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }

    }
}
