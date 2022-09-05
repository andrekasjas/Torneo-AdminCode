using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioPosicion
    {
        Posicion AddPosicion(Posicion posicion);
        IEnumerable<Posicion> GetAllPosiciones();
    }
}