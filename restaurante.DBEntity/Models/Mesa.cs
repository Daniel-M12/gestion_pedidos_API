using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;


namespace DBEntity
{
	public class Mesa
	{
        public int id_mesa { get; set; }
        public string nombre { get; set; }
        public bool ocupada { get; set; }
    }
}

