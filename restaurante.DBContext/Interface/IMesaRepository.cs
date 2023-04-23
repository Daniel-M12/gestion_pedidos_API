using System;
using DBEntity;


namespace DBContext
{
	public interface IMesaRepository
	{
        IEnumerable<Mesa> getMesas();
    }
}

