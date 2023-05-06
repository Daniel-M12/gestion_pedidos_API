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

        public EntityBaseResponse getPedidos()
        {
            var response = new EntityBaseResponse();

            try
            {
                var pedidos = context.pedidos;


                if (pedidos != null)
                {
                    response.isSuccess = true;
                    response.errorCode = "0000";
                    response.errorMessage = "";
                    response.data = pedidos;
                }
                else
                {
                    response.isSuccess = false;
                    response.errorCode = "0000";
                    response.errorMessage = "";
                    response.data = null;
                }

            }
            catch (Exception e)
            {
                response.isSuccess = false;
                response.errorCode = "0001";
                response.errorMessage = e.Message;
                response.data = null;
            }

            return response;

        }

        public EntityBaseResponse insert(Pedido pedido)
        {
            var response = new EntityBaseResponse();

            try
            {
                var inserted = context.Add<Pedido>(pedido);
                context.SaveChanges();

                if (inserted != null)
                {
                    response.isSuccess = true;
                    response.errorCode = "0000";
                    response.errorMessage = "";
                    response.data = inserted;
                }
                else
                {
                    response.isSuccess = false;
                    response.errorCode = "0000";
                    response.errorMessage = "";
                    response.data = null;
                }

            }
            catch (Exception e)
            {
                response.isSuccess = false;
                response.errorCode = "0001";
                response.errorMessage = e.Message;
                response.data = null;
            }

            return response;
        }


    }
}

