using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                        
                        contexto.Articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;
                    }

                    foreach (var item in mantenimiento.Detalle)
                    {
                        contexto.Vehiculos.Find(item.VehiculoId).Mantenimiento += (int)item.Total;
                        
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

        public static bool Modificar(Mantenimiento mantenimiento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            
            try
            {
                var MantAnt = MantenimientosBLL.Buscar(mantenimiento.MantenimientoId);

                foreach (var item in MantAnt.Detalle)
                {
                    contexto.Articulos.Find(item.ArticuloId).Inventario += item.Cantidad;
                    

                    if(!mantenimiento.Detalle.ToList().Exists(m => m.Id == item.Id))
                    {
                        item.Articulo = null;
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in MantAnt.Detalle)
                {
                    contexto.Vehiculos.Find(item.VehiculoId).Mantenimiento += (int)item.Total;


                    if (!mantenimiento.Detalle.ToList().Exists(m => m.Id == item.Id))
                    {
                        item.Vehiculo = null;
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in mantenimiento.Detalle)
                {
                    contexto.Articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                foreach (var item in mantenimiento.Detalle)
                {
                    contexto.Vehiculos.Find(item.VehiculoId).Mantenimiento -= (int)item.Total;
                    //var Vehiculo = contexto.Vehiculos.Find(item.VehiculoId).Mantenimiento -= item.Cantidad;
                    

                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                decimal dif;
                dif = mantenimiento.Total - MantAnt.Total;

                contexto.Entry(mantenimiento).State = EntityState.Modified;

                var Vehiculo = contexto.Mantenimiento.Find(mantenimiento.VehiculoId);
                Vehiculo.Total += dif;

                if (contexto.SaveChanges() > 0)
                {
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
                    var arti = contexto.Articulos.Find(item.ArticuloId).Inventario += item.Cantidad;
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

        public static Mantenimiento Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Mantenimiento mantenimiento = new Mantenimiento();

            try
            {
                mantenimiento = contexto.Mantenimiento.Find(id);

                if(mantenimiento != null)
                {
                    mantenimiento.Detalle.Count();

                    foreach (var item in mantenimiento.Detalle)
                    {
                        string d = item.Articulo.Descripcion;
                        string n = item.Vehiculo.Descripcion;
                    }
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

            return mantenimiento;
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
