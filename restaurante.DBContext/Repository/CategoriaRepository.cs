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

        public string insert(Categoria categoria)
        {
            try
            {
                context.Add<Categoria>(categoria);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                return e.Message;
            }

            return "Nueva categoría añadida";
        }
    }
}

