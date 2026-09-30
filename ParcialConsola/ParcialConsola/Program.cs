using AccesoDatosParcial.Models;
using AccesoDatosParcial.Repositories;
using System;
using Microsoft.EntityFrameworkCore;

IGenericRepository<Artista> artistaRepository = new GenericRepository<Artista>();
CancionesRepository cancionesRepository = new CancionesRepository();

bool continuar = true;

while (continuar)
{
    Console.WriteLine("1. Alta Artista");
    Console.WriteLine("2. Alta Canción");
    Console.WriteLine("3. Ver Canciones");
    Console.WriteLine("4. Mostrar canciones mas largas");
    Console.WriteLine("5. Mostrar total cantidad de canciones");
    Console.WriteLine("6. Mostrar canciones ordenadas alfabeticamente por titulo");
    Console.WriteLine("7. Verificar si existen canciones registradas");
    Console.WriteLine("0. Salir");
    Console.WriteLine();

    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();

    Console.Clear();

    switch (opcion)
    {
        case "1":
            AltaArtista();
            break;

        case "2":
            AltaCancion();
            break;

        case "3":
            VerCanciones();
            break;

        case "4":
            MostrarCancionesMasLargas();
            break;

        case "5":
            MostrarCantidadCanciones();
            break;

        case "6":
            MostrarCancionesOrdenadasPorTitulo();
            break;

        case "7":
            VerificarCancionesRegistradas();
            break;
        case "0":
            continuar = false;
            Console.WriteLine("Aplicación finalizada.");
            break;

        default:
            Console.WriteLine("Opción inválida.");
            PresioneParaContinuar();
            break;
    }
}

void AltaArtista()
{
    Console.Write("Nombre del artista: ");

    Artista artista = new Artista
    {
        Name = Console.ReadLine()
    };

    artistaRepository.Agregar(artista);

    Console.WriteLine("Artista registrado correctamente.");

    PresioneParaContinuar();
}
void AltaCancion()
{
    Console.Write("Título: ");
    string titulo = Console.ReadLine();

    Console.Write("Duración (en segundos): ");
    int duracion = 0;
    if (!int.TryParse(Console.ReadLine(), out duracion))
    {
        Console.WriteLine("Duración inválida. Debe ser un número entero.");
        return;
    }
    Console.WriteLine("Artistas disponibles:");

    foreach (var Artista in artistaRepository.ObtenerTodos())
    {
        Console.WriteLine(
            $"ID: {Artista.Id} - {Artista.Name}");
    }

    Console.Write("Seleccione el ID del artista: ");
    int artistaId = 0;
    if (!int.TryParse(Console.ReadLine(), out artistaId))
    {
        Console.WriteLine("ID de artista inválido. Debe ser un número entero.");
        return;
    }

    Cancion cancion = new Cancion
    {
        Titulo = titulo,
        DuracionEnSeg = duracion,
        ArtistaId = artistaId,
    };

    cancionesRepository.Agregar(cancion);

    Console.WriteLine("Canción registrada correctamente.");

    PresioneParaContinuar();
}
void VerCanciones()
{
    Console.WriteLine("===== CANCIONES =====");

    var canciones = cancionesRepository.ObtenerTodos();

    foreach (var cancion in canciones)
    {
        Console.WriteLine(
            $"ID: {cancion.Id} | Nombre: {cancion.Titulo} | Duración: {cancion.DuracionEnSeg}");
    }

    PresioneParaContinuar();
}
void MostrarCancionesMasLargas()
{
    Console.WriteLine("===== CANCIONES MÁS LARGAS =====");
    var cancionesMasLargas = cancionesRepository.ObtenerCancionesMasLargas();
    foreach (var cancion in cancionesMasLargas)
    {
        Console.WriteLine(
            $"ID: {cancion.Id} | Nombre: {cancion.Titulo} | Duración: {cancion.DuracionEnSeg}");
    }
    PresioneParaContinuar();
}
void MostrarCantidadCanciones()
{
    Console.WriteLine("===== CANTIDAD TOTAL DE CANCIONES =====");

    Console.WriteLine(
        $"Cantidad: {cancionesRepository.ContarCanciones()}");

    PresioneParaContinuar();
}
void MostrarCancionesOrdenadasPorTitulo()
{
    Console.WriteLine("===== CANCIONES ORDENADAS ALFABÉTICAMENTE POR TÍTULO =====");
    var cancionesOrdenadas = cancionesRepository.OrdenarAlfabeticamente();
    foreach (var cancion in cancionesOrdenadas)
    {
        Console.WriteLine(
            $"ID: {cancion.Id} | Nombre: {cancion.Titulo} | Duración: {cancion.DuracionEnSeg}");
    }
    PresioneParaContinuar();
}
void VerificarCancionesRegistradas()
{
    Console.WriteLine("===== VERIFICAR EXISTENCIA DE CANCIONES =====");
    bool existenCanciones = cancionesRepository.ExisteCancion();
    if (existenCanciones)
    {
        Console.WriteLine("Existen canciones registradas.");
    }
    else
    {
        Console.WriteLine("No existen canciones registradas.");
    }
    PresioneParaContinuar();
}
void PresioneParaContinuar()
{
    Console.WriteLine();
    Console.WriteLine("Presione una tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}