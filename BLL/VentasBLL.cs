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
    public class VentasBLL
    {
        public static bool Guardar(Ventas ventas)
        {
            if (!Existe(ventas.VentaId))
                return Insertar(ventas);
            else
                return Modificar(ventas);
        }

        private static bool Insertar(Ventas ventas)
        {
            bool paso = false;
            Contexto db = new Contexto();


            try
            {
                if (db.Venta.Add(ventas) != null)
                {

                    Clientes clientes = BLL.ClientesBLL.Buscar(ventas.VentaId);

                    clientes.Balance += ventas.Balance;

                    BLL.ClientesBLL.Modificar(clientes);

                    db.SaveChanges();
                    paso = true;


                }

                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return paso;

        }


        public static bool Modificar(Ventas ventas)
        {

            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var cliente = BLL.ClientesBLL.Buscar(ventas.ClienteId);
                var anterior = Buscar(ventas.VentaId);

                cliente.Balance -= anterior.Balance;
                db.Venta.Add(ventas);


                cliente.Balance += ventas.Balance;
                BLL.ClientesBLL.Modificar(cliente);

                db.Entry(ventas).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }


            return paso;

        }



        public static bool Eliminar(int id)
        {

            bool paso = false;
            Contexto db = new Contexto();
            Ventas ventas = new Ventas();


            try
            {
                ventas = db.Venta.Find(id);
                db.Cliente.Find(ventas.ClienteId).Balance -= ventas.Balance;


                db.Entry(ventas).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;

        }


        public static Ventas Buscar(int id)
        {

            Contexto db = new Contexto();
            Ventas ventas = new Ventas();
            Clientes clientes = new Clientes();

            try
            {

                ventas = db.Venta.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return ventas;


        }


        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();


            try
            {

                encontrado = db.Venta.Any(p => p.VentaId == id);


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return encontrado;

        }

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> expression)
        {


            List<Ventas> lista = new List<Ventas>();
            Contexto db = new Contexto();


            try
            {
                lista = db.Venta.Where(expression).ToList();
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
