using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SegundoParcial.BLL
{
    public class MantenimientosBLL
    {
        public static bool Guardar(Mantenimiento mantenimiento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if(contexto.Mantenimiento.Add(mantenimiento) != null)
                {
                    foreach (var item in mantenimiento.Detalle)
                    {
                        contexto.Vehiculos.Find(item.VehiculoId).Mantenimiento += (int)item.Total;
                    }

                    foreach (var item in mantenimiento.Detalle)
                    {
                        contexto.Articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;

                    }

                    contexto.SaveChanges();
                    paso = true;
                }
            }
            catch(Exception)
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
                Mantenimiento mantenimiento = contexto.Mantenimiento.Find(id);

                foreach (var item in mantenimiento.Detalle)
                {
                    var veh = contexto.Vehiculos.Find(item.VehiculoId).Mantenimiento -= (int)item.Total;
                }

                foreach (var item in mantenimiento.Detalle)
                {
                    var arti = contexto.Articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;
                }

                contexto.Mantenimiento.Remove(mantenimiento);

                if(contexto.SaveChanges() > 0)
                {
                    paso = true;
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

        public static List<Mantenimiento> GetList(Expression<Func<Mantenimiento,bool>>expression)
        {
            List<Mantenimiento> list = new List<Mantenimiento>();
            Contexto contexto = new Contexto();

            try
            {
                list = contexto.Mantenimiento.Where(expression).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return list;
        }


    }
}
