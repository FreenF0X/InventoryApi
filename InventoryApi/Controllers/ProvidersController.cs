using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BuisnessLogic;
using Domain.DtoModels;

namespace TMS.Operations.Controllers
{
    [ApiController]
    [Route("providers")]
    public class ProviderController : Controller
    {
        private readonly ProviderLogic logic;

        public ProviderController(ProviderLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProviders()
        {
            try
            {
                return Ok(await logic.GetAllProvidersAsync());
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProviderById(int id)
        {
            try
            {
                return this.Ok(await logic.GetProviderByIdAsync(id));
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProvider(DtoProvider Provider)
        {
            try
            {
                return this.Ok(await logic.CreateNewProviderAsync(Provider));
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider(int id)
        {
            try
            {
                return this.Ok(await logic.DeleteProviderAsync(id));
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateProviderById(DtoProvider Provider)
        {
            try
            {
                return this.Ok(await logic.UpdateProviderAsync(Provider));
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }
    }
}
