using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("------APLICACION TORNEO ADMIN CODE-------");
            Console.WriteLine("Elija una opción:");
            Console.WriteLine("");
            int opcion = 0;
            do
            {
                Console.WriteLine("1. Insertar Municipio");
                Console.WriteLine("2. Insertar Jugador");

                Console.WriteLine("0. Salir");
                opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        AddMunicipio();
                        break;

                    case 2:
                        AddJugador();
                        break;
                }
            }  while(opcion !=0);
        }

                private static void AddJugador()
        {
            Console.WriteLine("Ingrese el nombre del Jugador");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el número del jugador");
            int numero = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del equipo");
            int idEquipo = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id de la posición");
            int idPosicion = Int32.Parse(Console.ReadLine());
            var jugador = new Jugador
            {
                Nombre = nombre,
                Numero = numero,
            };
            _repoJugador.AddJugador(jugador, idEquipo, idPosicion);
        }

        private static void AddMunicipio()
        {
            var municipio = new Municipio
            {
                Nombre = "Manizales",
            };
            _repoMunicipio.AddMunicipio(municipio);
        }

        private static void GetAllJugadores()
        {
            foreach (var jugador in _repoJugador.GetAllJugadores())
            {
                Console.WriteLine("ID: "+ jugador.Id + " NOMBRE: " + jugador.Nombre + " EQUIPO: " + jugador.Equipo.Nombre + " POSICION: " + jugador.Posicion.Nombre);
            }
        }
    }
}