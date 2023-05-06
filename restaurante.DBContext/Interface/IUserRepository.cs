using System;
using DBEntity;

namespace DBContext
{
	public interface IUserRepository
	{
		EntityBaseResponse Login(EntityLogin login);

		EntityBaseResponse Insert(EntityUser user);
	}
}

