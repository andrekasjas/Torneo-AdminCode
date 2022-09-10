using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly DataContext _dataContext = new DataContext();
        public Partido AddPartido(Partido partido, int idEquipoLocal, int idEquipoVisitante)
        {
            var equipoLocalEncontrado = _dataContext.Equipos.Find(idEquipoLocal);
            var equipoVisitanteEncontrado = _dataContext.Equipos.Find(idEquipoVisitante);
            partido.Local = equipoLocalEncontrado;
            partido.Visitante = equipoVisitanteEncontrado;
            var partidoInsertado = _dataContext.Partidos.Add(partido);
            _dataContext.SaveChanges();
            return partidoInsertado.Entity;
        }
        public IEnumerable<Partido> GetAllPartidos()
        {
            var partidos = _dataContext.Partidos
                            .Include(p => p.Local)
                            .Include(p => p.Visitante)
                            .ToList();
            return partidos;
        }
        public Partido GetPartido(int idPartido)
        {
            var partido = _dataContext.Partidos
                            .Include(p => p.Local)
                            .Include(p => p.Visitante)
                            .FirstOrDefault(p => p.Id == idPartido);
            return partido;
        }
    }
}