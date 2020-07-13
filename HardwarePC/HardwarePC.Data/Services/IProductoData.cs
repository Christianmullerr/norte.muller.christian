using HardwarePC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Services
{
    public interface IProductoData
    {
        IEnumerable<Product> GetAll();

        void Insert(Product objProducto);

        void Update(Product objProducto);
    }
}
