using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;


namespace DBEntity
{
	public class Pedido
	{
        public int id_pedido { get; set; }
        public DateTime fecha { get; set; }
        public bool atendido { get; set; }
        //public int mesa { get; set; }
    }
}

