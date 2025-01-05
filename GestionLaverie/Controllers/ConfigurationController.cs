using GestionLaverie.Domaine.Entities;
using liveriAPI.Model.Business;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<List<Proprietaire>> GetPropriétairesWithDetails()
        {
            try
            {
                var result = _business.GetAllPropriétairesWithDetails();
                if (result.Count == 0)
                {
                    return NotFound("No proprietors found.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
