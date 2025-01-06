using GestionLaverie.Domaine.Entities;
using liveriAPI.Model.Domaine;
using System.Collections.Generic;

namespace liveriAPI.Model.Business
{
    public class ConfigurationBusiness
    {
        private readonly IProprietaireDAO _proprietaireDao;

        public ConfigurationBusiness(IProprietaireDAO proprietaireDao)
        {
            _proprietaireDao = proprietaireDao;
        }

        public List<Proprietaire> GetAllPropriétairesWithDetails()
        {
            var proprietaires = _proprietaireDao.GetAllPropriétairesWithDetails();
            return proprietaires ?? new List<Proprietaire>();
        }
    }
}
