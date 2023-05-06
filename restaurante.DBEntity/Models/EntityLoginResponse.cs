using System;
namespace DBEntity
{
	public class EntityLoginResponse
	{
        public int id_usuario { get; set; }
        public int rol { get; set; }
        public string dni { get; set; }
        public string token { get; set; }
    }
}

