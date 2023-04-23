using System;
using DBEntity;

namespace DBContext
{
	public class PedidoRepository: IPedidoRepository
	{
        RestauranteContext context;

		public PedidoRepository(RestauranteContext dbcontext)
		{
            this.context = dbcontext;
		}

        public IEnumerable<Pedido> getPedidos()
        {
            return context.pedidos;
        }
    }
}

