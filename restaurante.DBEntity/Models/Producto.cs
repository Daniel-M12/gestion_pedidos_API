using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;


namespace DBEntity
{
    public class Producto
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string? descripcion { get; set; }
        public double precio { get; set; }
        public string imagen { get; set; }
        public bool activo { get; set; }

    }
}



