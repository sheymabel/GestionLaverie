using GestionLaverie.Domaine.Entities;
using liveriAPI.Model.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace liveriAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly ConfigurationBusiness _business;

        public ConfigurationController(ConfigurationBusiness configBusiness)
        {
            _business = configBusiness;
        }

        [HttpGet("proprietaires")]
        public ActionResult<List<Proprietaire>> GetProprietairesWithDetails()
        {
            try
            {
                var result = _business.GetAllPropriétairesWithDetails();

                if (result.Count == 0)
                {
                    return NotFound("Aucun propriétaire trouvé.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
            }
        }
    }
}
