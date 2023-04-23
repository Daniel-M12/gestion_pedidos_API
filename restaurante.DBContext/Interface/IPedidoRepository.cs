using System;
using DBEntity;


namespace DBContext
{
	public interface IPedidoRepository
	{
        IEnumerable<Pedido> getPedidos();
    }
}

