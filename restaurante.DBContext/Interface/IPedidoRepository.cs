using System;
using DBEntity;


namespace DBContext
{
	public interface IPedidoRepository
	{
        EntityBaseResponse getPedidos();

        EntityBaseResponse insert(Pedido pedido);
    }
}

