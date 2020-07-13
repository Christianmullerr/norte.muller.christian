using HardwarePC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Services
{
    public class InMemoryProductoData : BaseDataService<Producto>
    {

        private static List<Producto> productos;

        public InMemoryProductoData()
        {
            /*
            if (productos is null)
            {
                productos = new List<Producto>
                {
                    new Producto() { Id = 1, Title = "Acer Aspire E 15", Description = "Notebooks"},
                    new Producto() { Id = 2, Title = "WD M2 Blue 240gb", Description = "Almacenamiento" },
                    new Producto() { Id = 3, Title = "Teclado Logitech", Description = "Periféricos" }
                };
            }
            */
        }

        /*
        public override List<Producto> Get(Expression<Func<Producto, bool>> whereExpression = null, Func<IQueryable<Producto>, IOrderedQueryable<Producto>> orderFunction = null, string includeEntities = "")
        {
            return productos.OrderBy(o => o.Title).ToList();
        }
        */


        /*
        public override Producto Create(Producto entity)
        {
            productos.Add(entity);

            return base.Create(entity);
        }
        */

        /*
        public IEnumerable<Producto> GetAll()
        {
            return productos.OrderBy(o => o.Title);
        }
        */
    }
}
