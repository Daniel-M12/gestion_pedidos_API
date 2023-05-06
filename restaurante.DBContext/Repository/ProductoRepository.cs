using System;
using DBEntity;

namespace DBContext
{
	public class ProductoRepository: IProductoRepository
	{
        RestauranteContext context;

		public ProductoRepository(RestauranteContext dbcontext)
		{
            this.context = dbcontext;
		}

        public EntityBaseResponse getProductos()
        {
            var response = new EntityBaseResponse();

            try
            {
                var productos = context.productos;


                if (productos != null)
                {
                    response.isSuccess = true;
                    response.errorCode = "0000";
                    response.errorMessage = "";
                    response.data = productos;
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

        public EntityBaseResponse insert(Producto producto)
        {
            var response = new EntityBaseResponse();

            try
            {
                var inserted = context.Add<Producto>(producto);
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

