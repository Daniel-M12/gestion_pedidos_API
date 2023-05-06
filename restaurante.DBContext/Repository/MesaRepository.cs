using System;
using DBEntity;

namespace DBContext
{
	public class MesaRepository: IMesaRepository
	{
        RestauranteContext context;

        public MesaRepository(RestauranteContext dbcontext)
		{
            this.context = dbcontext;
		}

        public EntityBaseResponse getMesas()
        {
            var response = new EntityBaseResponse();

            try
            {
                var mesas = context.mesas;


                if (mesas != null)
                {
                    response.isSuccess = true;
                    response.errorCode = "0000";
                    response.errorMessage = "";
                    response.data = mesas;
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

        public EntityBaseResponse insert(Mesa mesa)
        {
            var response = new EntityBaseResponse();

            try
            {
                var inserted = context.Add<Mesa>(mesa);
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

