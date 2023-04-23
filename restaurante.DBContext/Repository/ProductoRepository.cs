using System;
using DBEntity;

namespace DBContext
{
	public class ProductoRepository: IProductoRepository
	{
        RestauranteContext context;

		public ProductoRepository(RestauranteContext dbcontext)
		{
            context = dbcontext;
		}

        public IEnumerable<Producto> getProductos()
        {
            return context.productos;
        }

        //public void Save(Producto producto)
    }
}

