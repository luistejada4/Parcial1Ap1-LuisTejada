using Parcial1Ap1_LuisTejada.DAL;
using Parcial1Ap1_LuisTejada.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1Ap1_LuisTejada.BLL
{
    public class EmpleadoBLL
    {
        public static int Guardar(Empleados e)
        {
            using (var db = new ParcialDB())
            {
                try
                {
                    if (Buscar(e.EmpleadoId) == null)
                    {
                        db.Empleados.Add(e);
                        db.SaveChanges();
                        return e.EmpleadoId;
                    }
                    else
                    {
                        db.Entry(e).State = EntityState.Modified;
                        db.SaveChanges();
                        return e.EmpleadoId;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static Empleados Buscar(int id)
        {
            using (var db = new ParcialDB())
            {
                try
                {
                    Empleados e = db.Empleados.Find(id);
                    if (e != null)
                    {
                        db.SaveChanges();
                        return e;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static bool Eliminar(int id)
        {
            using (var db = new ParcialDB())
            {
                try
                {
                    Empleados e = Buscar(id);
                    if (e != null)
                    {
                        db.Entry(e).State = EntityState.Deleted;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static List<Empleados> GetList()
        {
            using (var db = new ParcialDB())
            {
                try
                {
                    return db.Empleados.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static List<Empleados> GetListFecha(DateTime desde, DateTime hasta)
        {
            using (var db = new ParcialDB())
            {
                try
                {
                    return db.Empleados.Where(e => e.FechaNacimientos >= desde.Date && e.FechaNacimientos <= hasta.Date).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static List<Empleados> GetListNombre(string nombre)
        {
            using (var db = new ParcialDB())
            {
                try
                {
                    return db.Empleados.Where(e => e.Nombres == nombre).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static List<Empleados> GetListFechaAndNombre(DateTime desde, DateTime hasta, string nombre)
        {
            using (var db = new ParcialDB())
            {
                try
                {
                    return db.Empleados.Where(e => e.FechaNacimientos >= desde.Date && e.FechaNacimientos <= hasta.Date && e.Nombres == nombre).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
