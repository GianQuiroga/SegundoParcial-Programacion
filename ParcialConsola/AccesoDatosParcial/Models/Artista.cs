using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatosParcial.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Cancion> Canciones { get; set; } = new List<Cancion>();
    }
}
