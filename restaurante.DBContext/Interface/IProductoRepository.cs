using System;
using DBEntity;


namespace DBContext
{
	public interface IProductoRepository
	{
        EntityBaseResponse getProductos();

		EntityBaseResponse insert(Producto producto);
	}
}

