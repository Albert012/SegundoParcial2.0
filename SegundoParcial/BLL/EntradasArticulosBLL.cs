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
        public static bool Guardar(EntradasArticulos entrada)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            //Repositorio<Articulos> repositorio = new Repositorio<Articulos>(contexto);
            
            try
            {
                if (contexto.Entradas.Add(entrada) != null)
                {
                    Articulos articulos = BLL.ArticulosBLL.Buscar(entrada.ArticuloId);
                    articulos.Inventario += entrada.Cantidad;
                    BLL.ArticulosBLL.Modificar(articulos);

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

        public static bool Modificar(EntradasArticulos entrada)
        {
            bool paso = false;            
            Contexto contexto = new Contexto();
            EntradasArticulos EntradaAnt = BLL.EntradasArticulosBLL.Buscar(entrada.EntradaId);
            int dif;
            dif = entrada.Cantidad - EntradaAnt.Cantidad;

            Articulos articulos = BLL.ArticulosBLL.Buscar(entrada.ArticuloId);
            articulos.Inventario += dif;
            BLL.ArticulosBLL.Modificar(articulos);

            try
            {
                contexto.Entry(entrada).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();         

            try
            {
                EntradasArticulos entrada = contexto.Entradas.Find(id);
                Articulos articulos = BLL.ArticulosBLL.Buscar(entrada.ArticuloId);
                articulos.Inventario -= entrada.Cantidad;
                BLL.ArticulosBLL.Modificar(articulos);

                contexto.Entradas.Remove(entrada);

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
            EntradasArticulos entradasArticulos = new EntradasArticulos();

            try
            {
                entradasArticulos = contexto.Entradas.Find(id);

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return entradasArticulos;
        }


    }
}
