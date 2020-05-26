using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Tarea2.Entidades;
using Tarea2.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Tarea2.BLL
{
    class RegistroBLL
    {
        public static bool Guardar (Registro registro)
        {
            if (!Existe(registro.id))
                return Insertar(registro);
            else
                return Modificar(registro);
        }

        public static bool Insertar(Registro registro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Registro.Add(registro);
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

        public static bool Modificar(Registro registro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(registro).State = EntityState.Modified;
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

        public static bool Modificar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var registro = contexto.Registro.Find(id);
                if (registro != null)
                {
                    contexto.Registro.Remove(registro);
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

        public static Registro Guardar(int id)
        {
            Contexto contexto = new Contexto();
            Registro registro;

            try
            {
                registro = contexto.Registro.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return registro;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encotrado = false;

            try
            {
                encotrado = contexto.Registro.Any(e => e.id == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encotrado;
        }

        public static List<Registro> GetList(Expression<Func<Registro,bool >>cristerio)
        {
            List<Registro> lista = new List<Registro>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Registro.Where(cristerio).ToList();
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
