﻿using System;
using DBEntity;


namespace DBContext
{
	public interface ICategoriaRepository
	{
        IEnumerable<Categoria> getCategorias();
    }
}

