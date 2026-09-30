using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatosParcial.Models
{
    public class Cancion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int DuracionEnSeg { get; set; }
        public int ArtistaId { get; set; }
        public Artista Artista { get; set; }
    }
}
