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

        public IEnumerable<Categoria> getCategorias()
        {
            return context.categorias;
        }
    }
}

