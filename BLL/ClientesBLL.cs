using FinalProject.DAL;
using FinalProject.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.BLL
{
    public class ClientesBLL
    {
        public static bool Guardar(Clientes clientes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Cliente.Add(clientes) != null)
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

        public static bool Modificar(Clientes clientes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {

                {
                    db.Entry(clientes).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);
                }


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
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Cliente.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Clientes Buscar(int id)
        {
            Clientes clientes = new Clientes();
            Contexto contexto = new Contexto();

            try
            {
                clientes = contexto.Cliente.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return clientes;
        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> clientes)
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Cliente.Where(clientes).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }
    }
}
