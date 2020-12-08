using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;
using FinalProject.Entidades;
using FinalProject.DAL;

namespace FinalProject.BLL
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            if (!Existe(usuario.UsuarioId))
                return Insertar(usuario);
            else
                return Modificar(usuario);
        }

        private static bool Insertar(Usuarios usuario)
        {
            if (usuario.UsuarioId != 0)
                return false;

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                usuario.Contrasena = Encrypt(usuario.Contrasena);

                if (contexto.Usuario.Add(usuario) != null)
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

        private static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                usuario.Contrasena = Encrypt(usuario.Contrasena);

                contexto.Entry(usuario).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
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

        public static string Encrypt(string cadenaEncriptada)
        {
            if (!string.IsNullOrEmpty(cadenaEncriptada))
            {
                string val = string.Empty;
                byte[] encryted = Encoding.Unicode.GetBytes(cadenaEncriptada);
                val = Convert.ToBase64String(encryted);

                return val;
            }
            return string.Empty;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var usuario = contexto.Usuario.Find(id);
                if(usuario != null)
                {
                    contexto.Usuario.Remove(usuario);
                    paso = contexto.SaveChanges() > 0;
                }
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
        public static Usuarios Buscar(int id)
        {
            Usuarios usuario = new Usuarios();
            Contexto contexto = new Contexto();
            try
            {
                usuario = contexto.Usuario.Find(id);
                if (usuario != null)
                    usuario.Contrasena = desEncriptar(usuario.Contrasena); ;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuario;
        }

        public static string desEncriptar(string cadenaDesencriptada)
        {
            if (!string.IsNullOrEmpty(cadenaDesencriptada))
            {
                string val = string.Empty;
                byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
                val = System.Text.Encoding.Unicode.GetString(decryted);

                return val;
            }
            return string.Empty;
        }

        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Usuario.Any(u => u.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> usuario)
        {
            List<Usuarios> Lista = new List<Usuarios>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.Usuario.Where(usuario).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        public static bool ExisteUsuario(string usuario, string clave)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                clave = Encrypt(clave);

                if (contexto.Usuario.Where(u => u.NombreUsuario == usuario && u.Contrasena == clave).FirstOrDefault() != null)
                    paso = true;
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

        public static string ObtenerUsuarioId(string usuario, string clave)
        {
            Contexto contexto = new Contexto();
            string id;

            try
            {
                clave = Encrypt(clave);

                id = contexto.Usuario.Where(u => u.NombreUsuario == usuario && u.Contrasena == clave).FirstOrDefault().UsuarioId.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return id;
        }
    }
}
