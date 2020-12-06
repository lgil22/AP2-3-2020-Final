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
    public class CobrosBLL
    {
        public static bool Guardar(Cobros cobro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Cobro.Add(cobro) != null)
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

        private static bool Insertar(Cobros cobro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Cobro.Add(cobro) != null)
                {
                    foreach (var item in cobro.Detalle)
                    {
                        contexto.Venta.Find(item.VentaId).Balance += item.Monto;
                    }
                }
                contexto.Cobro.Add(cobro);
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


        public static bool Modificar(Cobros cobro)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Cobros cobro_anterior = contexto.Cobro.Where(e => e.CobroId == cobro.CobroId)
                    .Include(d => d.Detalle)
                    .FirstOrDefault();

                contexto = new Contexto();

                foreach (var item in cobro_anterior.Detalle)
                {
                    if (!cobro.Detalle.Any(d => d.Id == item.Id))
                    {
                        contexto.Venta.Find(item.VentaId).Balance -= item.Monto;
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in cobro.Detalle)
                {
                    if (item.Id == 0)
                    {
                        contexto.Venta.Find(item.VentaId).Balance += item.Monto;
                        contexto.Entry(item).State = EntityState.Added;

                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;

                    }
                }

                contexto.Entry(cobro).State = EntityState.Modified;
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


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            try
            {
                Cobros cobros = contexto.Cobro.Where(e => e.CobroId == id).Include(d => d.Detalle).FirstOrDefault();

                foreach (var item in cobros.Detalle)
                {
                    contexto.Venta.Find(item.CobroId).Balance -= item.Monto;

                }

                contexto.Cobro.Remove(cobros);
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



        public static Cobros Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Cobros cobro = new Cobros();

            try
            {
                cobro = contexto.Cobro.Include(x => x.Detalle)
                    .Where(x => x.CobroId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return cobro;
        }

        public static List<Cobros> GetList(Expression<Func<Cobros, bool>> cobro)
        {
            List<Cobros> lista = new List<Cobros>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Cobro.Where(cobro).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
