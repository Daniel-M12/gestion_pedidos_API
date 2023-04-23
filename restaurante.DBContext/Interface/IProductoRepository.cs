using System;
using DBEntity;


namespace DBContext
{
	public interface IProductoRepository
	{
        IEnumerable<Producto> getProductos();
		
	}
}

