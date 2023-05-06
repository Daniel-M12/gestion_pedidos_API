using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;
using System.Threading;

namespace DBEntity
{
	public class Categoria
	{
        public int id_categoria { get; set; }
        public string nombre { get; set; }
        public string? descripcion { get; set; }

        /*[JsonIgnore]
        public virtual ICollection<Producto> productos { get; set; }*/
    }
}

