using GestionLaverie.Domaine.Entities;
using liveriAPI.Model.Domaine;

namespace liveriAPI.Model.Business
{
    public class ConfigurationBusiness
    {
        public readonly IProprietaireDAO _ProprietaireDAO;

        public ConfigurationBusiness(IProprietaireDAO proprietaireDao)
        {
            _ProprietaireDAO = proprietaireDao;
        }

        public List<Proprietaire> GetAllPropriétairesWithDetails()
        {
            var proprietaires = _ProprietaireDAO.GetAllPropriétairesWithDetails();
            return proprietaires ?? new List<Proprietaire>();
        }
    }
}
