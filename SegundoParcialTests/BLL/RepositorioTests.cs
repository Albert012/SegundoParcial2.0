using Microsoft.VisualStudio.TestTools.UnitTesting;
using SegundoParcial.BLL;
using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoParcial.BLL.Tests
{
    [TestClass()]
    public class RepositorioTests
    {
        [TestMethod()]
        public void RepositorioTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            Articulos articulos = new Articulos();
            articulos.ArticuloId = 0;
            articulos.Descripcion = "Coolant";
            articulos.Costo = 200;
            articulos.Precio = 250;
            articulos.Ganancia = 50;
            articulos.Inventario = 0;
            paso = repositorio.Guardar(articulos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            Articulos articulos = new Articulos();
            articulos.ArticuloId = 3;
            articulos.Descripcion = "Coolant";
            articulos.Costo = 250;
            articulos.Precio = 300;
            articulos.Ganancia = 50;
            articulos.Inventario = 0;
            paso = repositorio.Modificar(articulos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            
            paso = repositorio.Eliminar(3);
            Assert.AreEqual(paso, true);



        }

        [TestMethod()]
        public void BuscarTest()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            Articulos articulos = new Articulos();
            articulos = repositorio.Buscar(2);
            Assert.IsNotNull(articulos);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            var articulos = repositorio.GetList(a => true);
            Assert.IsNotNull(articulos);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}