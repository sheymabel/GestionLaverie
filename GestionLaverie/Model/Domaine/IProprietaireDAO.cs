using GestionLaverie.Domaine.Entities;

namespace liveriAPI.Model.Domaine
{
    public interface IProprietaireDAO
    {
        List<Proprietaire>? GetAllPropriétairesWithDetails();
    }
}
