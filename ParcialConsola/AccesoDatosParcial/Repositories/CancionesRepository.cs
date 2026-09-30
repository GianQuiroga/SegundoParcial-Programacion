using System;
using System.Collections.Generic;
using System.Text;
using AccesoDatosParcial.Models;

namespace AccesoDatosParcial.Repositories
{
    public class CancionesRepository: GenericRepository<Cancion>
    {
        public List<Cancion> ObtenerCancionesMasLargas()
        {
            return _context.Canciones
                .OrderByDescending(c => c.DuracionEnSeg)
                .ToList();
        }

        public int ContarCanciones()
        {
            return _context.Canciones.Count();
        }
        
        public List<Cancion> OrdenarAlfabeticamente()
        {
            return _context.Canciones
                .OrderBy(c => c.Titulo)
                .ToList();
        }
        public bool ExisteCancion()
        {
            return _context.Canciones.Any();
        }

    }
}
