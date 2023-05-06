using System;
using DBEntity;


namespace DBContext
{
	public class CategoriaRepository: ICategoriaRepository
	{
        RestauranteContext context;

		public CategoriaRepository(RestauranteContext dbcontext)
		{
            this.context = dbcontext;
		}

        public EntityBaseResponse getCategorias()
        {
            var response = new EntityBaseResponse();

            try
            {
                var categorias = context.categorias;
                

                if (categorias != null)
                {
                    response.isSuccess = true;
                    response.errorCode = "0000";
                    response.errorMessage = "";
                    response.data = categorias;
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

        public EntityBaseResponse insert(Categoria categoria)
        {

            var response = new EntityBaseResponse();

            try
            {
                var inserted = context.Add<Categoria>(categoria);
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

