using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioPosicion
    {
        public Posicion AddPosicion(Posicion posicion);
        public IEnumerable<Posicion> GetAllPosiciones();
    }
}