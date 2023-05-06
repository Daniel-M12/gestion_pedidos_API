using System;
using DBEntity;


namespace DBContext
{
	public interface ICategoriaRepository
	{
        EntityBaseResponse getCategorias();

        EntityBaseResponse insert(Categoria categoria);
    }
}

