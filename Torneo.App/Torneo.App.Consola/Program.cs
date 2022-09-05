using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();
        private static IRepositorioPosicion _repoPosicion = new RepositorioPosicion();

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("1. Insertar Municipio");
                Console.WriteLine("2. Insertar Director Tecnico");
                Console.WriteLine("3. Insertar Equipo");
                Console.WriteLine("4. Insertar Partido");
                Console.WriteLine("5. Insertar Posicion");
                Console.WriteLine("6. Mostar Municipios");
                Console.WriteLine("7. Mostar Directores Tecnicos");
                Console.WriteLine("8. Mostar Equipos");
                Console.WriteLine("9. Mostar Partidos");
                Console.WriteLine("10. Mostar Posiciones");
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
                        AddPartido();
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
                        GetAllPartidos();
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

        private static void AddPartido()
        {
            Console.WriteLine("Ingrese el id del equipo Local");
            int idEquipoLocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del equipo Visitante");
            int idEquipoVisitante = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de goles del equipo Local");
            int golesEquipoLocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de goles del equipo Visitante");
            int golesEquipoVisitante = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha del partido");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            var partido = new Partido
            {
                Local = _repoEquipo.GetEquipo(idEquipoLocal),
                Visitante = _repoEquipo.GetEquipo(idEquipoVisitante),
                MarcadorLocal = golesEquipoLocal,
                MarcadorVisitante = golesEquipoVisitante,
                FechaHora = fecha,
            };
            _repoPartido.AddPartido(partido, idEquipoLocal, idEquipoVisitante);
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
                Console.WriteLine(municipio.Id + " " + municipio.Nombre);
            }
        }

        private static void GetAllDTs()
        {
            foreach (var dt in _repoDT.GetAllDTs())
            {
                Console.WriteLine(dt.Id + " " + dt.Nombre + " " + dt.Documento + " " + dt.Telefono);
            }
        }

        private static void GetAllEquipos()
        {
            foreach (var equipo in _repoEquipo.GetAllEquipos())
            {
                Console.WriteLine(equipo.Id + " " + equipo.Nombre + " " + equipo.Municipio.Nombre + " " + equipo.DirectorTecnico.Nombre);
            }
        }

        private static void GetAllPartidos()
        {
            foreach (var partido in _repoPartido.GetAllPartidos())
            {
                Console.WriteLine(partido.Id + " " + partido.Local.Nombre + " " + partido.Visitante.Nombre + " " + partido.MarcadorLocal + " " + partido.MarcadorVisitante + " " + partido.FechaHora);
            }
        }

        private static void GetAllPosiciones()
        {
            foreach (var posicion in _repoPosicion.GetAllPosiciones())
            {
                Console.WriteLine(posicion.Id + " " + posicion.Nombre);
            }
        }
    }
}