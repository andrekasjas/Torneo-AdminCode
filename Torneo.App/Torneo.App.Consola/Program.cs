﻿using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPosicion _repoPosicion = new RepositorioPosicion();


        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine(">>>>>>>>>>APLICACION TORNEO ADMIN CODE<<<<<<<<<<");
            Console.WriteLine("Elija una opción:");
            Console.WriteLine("");

            int opcion = 0;
            do
            {
                Console.WriteLine("1. Insertar Municipio");
                Console.WriteLine("2. Insertar Director Tecnico");
                Console.WriteLine("3. Insertar Equipo");
                Console.WriteLine("4. Insertar Jugador");
                Console.WriteLine("5. Insertar Posicion");
                Console.WriteLine("6. Mostar Municipios");
                Console.WriteLine("7. Mostar Directores Tecnicos");
                Console.WriteLine("8. Mostar Equipos");
                Console.WriteLine("9. Mostar Jugadores");
                Console.WriteLine("10. Mostar Posicion");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Ingrese una opcion");


                opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        AddMunicipio();
                        break;
                    case 2:
                        AddDT();
                        break;
                    case 3:
                        AddEquipo();
                        break;
                    case 4:
                        AddJugador();
                        break;
                    case 5:
                        AddPosicion();
                        break;
                    case 6:
                        GetAllMunicipios();
                        break;
                    case 7:
                        GetAllDTs();
                        break;
                    case 8:
                        GetAllEquipos();
                        break;
                    case 9:
                        GetAllJugadores();
                        break;
                    case 10:
                        GetAllPosiciones();
                        break;


                }
            } while (opcion != 0);
        }


        private static void AddMunicipio()
        {
            Console.WriteLine("Ingrese el nombre del municipio");
            string nombre = Console.ReadLine();
            var municipio = new Municipio
            {
                Nombre = nombre,
            };
            _repoMunicipio.AddMunicipio(municipio);
        }

        private static void AddDT()
        {
            Console.WriteLine("Ingrese el nombre del DT");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el documento del DT");
            string documento = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del DT");
            string telefono = Console.ReadLine();
            var dt = new DirectorTecnico
            {
                Nombre = nombre,
                Documento = documento,
                Telefono = telefono,
            };
            _repoDT.AddDT(dt);
        }

        private static void AddEquipo()
        {
            Console.WriteLine("Ingrese el nombre del equipo");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el id del municipio");
            int idMunicipio = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del DT");
            int idDT = Int32.Parse(Console.ReadLine());

            var equipo = new Equipo
            {
                Nombre = nombre,
            };
            _repoEquipo.AddEquipo(equipo, idMunicipio, idDT);
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

        private static void AddPosicion()
        {
            Console.WriteLine("Ingrese el nombre de la posicion");
            string nombre = Console.ReadLine();
            var posicion = new Posicion
            {
                Nombre = nombre,
            };
            _repoPosicion.AddPosicion(posicion);
        }



        private static void GetAllMunicipios()
        {
            foreach (var municipio in _repoMunicipio.GetAllMunicipios())
            {
                Console.WriteLine("ID: " + municipio.Id + " NOMBRE: " + municipio.Nombre);
            }
            Console.WriteLine("\n");
        }

        private static void GetAllJugadores()
        {
            foreach (var jugador in _repoJugador.GetAllJugadores())
            {
                Console.WriteLine("ID: " + jugador.Id + " NOMBRE: " + jugador.Nombre + " Número: " + jugador.Numero + " EQUIPO: " + jugador.Equipo.Nombre + " POSICION: " + jugador.Posicion.Nombre);
            }
            Console.WriteLine("\n");
        }

        private static void GetAllDTs()
        {
            foreach (var dt in _repoDT.GetAllDTs())
            {
                Console.WriteLine("ID: " + dt.Id + " NOMBRE: " + dt.Nombre + " DOCUMENTO: " + dt.Documento + " TELÉFONO: " + dt.Telefono);
            }
            Console.WriteLine("\n");
        }

        private static void GetAllEquipos()
        {
            foreach (var equipo in _repoEquipo.GetAllEquipos())
            {
                Console.WriteLine("ID: " + equipo.Id + " NOMBRE: " + equipo.Nombre + " MUNICIPIO: " + equipo.Municipio.Nombre + " DT: " + equipo.DirectorTecnico.Nombre);
            }
            Console.WriteLine("\n");
        }

        private static void GetAllPosiciones()
        {
            foreach (var posicion in _repoPosicion.GetAllPosiciones())
            {
                Console.WriteLine("ID: " + posicion.Id + " NOMBRE: " + posicion.Nombre);
            }
            Console.WriteLine("\n");
        }




    }

}


