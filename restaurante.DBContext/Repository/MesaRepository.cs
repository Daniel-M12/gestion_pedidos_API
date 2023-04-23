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

        public IEnumerable<Mesa> getMesas()
        {
            return context.mesas;
        }
    }
}

