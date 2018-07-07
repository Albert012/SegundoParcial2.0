using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SegundoParcial.BLL
{
    public interface IRepository<A> where A : class
    {
        bool Guardar(A entity);
        bool Modificar(A entity);
        bool Eliminar(int id);
        A Buscar(int id);
        List<A> GetList(Expression<Func<A, bool>> expression);
        //Decimal CalcularImporte(Decimal cantidad, Decimal precio);
        //Decimal CalcularSubTotal(Decimal importe);
        //Decimal CalcularItbis(Decimal subtotal);
        //Decimal CalcularTotal(Decimal subtotal, Decimal itbis);

    }
}
