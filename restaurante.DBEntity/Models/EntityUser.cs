using System;

namespace DBEntity
{
	public class EntityUser
	{
		public int id_usuario { get; set; }
		public string login_usuario { get; set; }
		public string password { get; set; }
		public int rol { get; set; }
		public string dni { get; set; }
	}
}

