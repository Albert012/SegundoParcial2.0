using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SegundoParcial.BLL
{
    public class EntradasArticulosBLL
    {
        public static bool Guardar(EntradasArticulos articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Entradas.Add(articulo) != null)
                {
                    foreach (var item in articulo.Detalle)
                    {
                        contexto.Articulos.Find(item.ArticuloId).Inventario += item.Cantidad;
                    }
                    contexto.SaveChanges();
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

        public static bool Modificar(EntradasArticulos articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var EntradaAnt = BLL.EntradasArticulosBLL.Buscar(articulo.EntradaId);

                foreach (var item in EntradaAnt.Detalle)
                {
                    contexto.Articulos.Find(item.ArticuloId).Inventario += item.Cantidad;

                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                contexto.Entry(articulo).State = EntityState.Modified;
                if(contexto.SaveChanges() > 0)
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
        
        public static EntradasArticulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            EntradasArticulos articulo = new EntradasArticulos();
           

            try
            {
                articulo = contexto.Entradas.Find(id);
                
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return articulo;
        }

    }
}
