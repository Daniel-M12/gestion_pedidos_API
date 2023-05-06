using System;
using DBEntity;


namespace DBContext
{
	public interface IMesaRepository
	{
        EntityBaseResponse getMesas();

        EntityBaseResponse insert(Mesa mesa);
    }
}

