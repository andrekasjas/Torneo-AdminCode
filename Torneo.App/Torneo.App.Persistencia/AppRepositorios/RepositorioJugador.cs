using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioJugador : IRepositorioJugador
    {
        private readonly DataContext _dataContext = new DataContext();
        public Jugador AddJugador(Jugador jugador, int idEquipo, int idPosicion)
        {
            var equipoEncontrado = _dataContext.Equipos.Find(idEquipo);
            var posicionEncontrada = _dataContext.Posiciones.Find(idPosicion);
            jugador.Equipo = equipoEncontrado;
            jugador.Posicion = posicionEncontrada;
            var jugadorInsertado = _dataContext.Jugadores.Add(jugador);
            _dataContext.SaveChanges();
            return jugadorInsertado.Entity;
        }
        public IEnumerable<Jugador> GetAllJugadores()
        {
            var jugadores = _dataContext.Jugadores
                            .Include(j => j.Equipo)
                            .Include(j => j.Posicion)
                            .ToList();
            return jugadores;
        }
    } 
}