using GestionLaverie.Domaine.Entities;

namespace liveriAPI.Model.Domaine
{
    public interface ILaverieDAO
    {
        List<Laverie> GetLaveriesByProprietaireId(int proprietaireId);
    }
}
