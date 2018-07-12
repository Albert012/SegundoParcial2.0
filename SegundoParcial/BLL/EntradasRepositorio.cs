using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using SegundoParcial.Entidades;
using SegundoParcial.DAL;

namespace SegundoParcial.BLL
{
    public class EntradasRepositorio : Repositorio<EntradasArticulos> 
    {
        public EntradasRepositorio(Contexto contexto) : base (contexto)
        {

        }

        public override EntradasArticulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            EntradasArticulos entradasArticulos = new EntradasArticulos();

            try
            {
                entradasArticulos = contexto.Entradas.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return entradasArticulos;
        }

        public override bool Modificar(EntradasArticulos entrada)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Repositorio<EntradasArticulos> repositorio = new Repositorio<EntradasArticulos>(contexto);
            Repositorio<Articulos> repositorio2 = new Repositorio<Articulos>(contexto);

            EntradasArticulos Ant = repositorio.Buscar(entrada.ArticuloId);
            int dif;
            dif = entrada.Cantidad - Ant.Cantidad;

            Articulos articulos = repositorio2.Buscar(entrada.ArticuloId);
            articulos.Inventario += dif;
            repositorio2.Modificar(articulos);

            try
            {
                contexto.Entry(entrada).State = EntityState.Modified;
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
    }
}
