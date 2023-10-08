using BlazorApp2.Server.Domain;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericFormController : ControllerBase
    {
        private readonly DataManager dataManager;

        public GenericFormController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpPut]
        public IActionResult CreateForm(GenericForm genericform)
        {
            dataManager.GenericFormRepository.Add(genericform);

            return Ok(genericform);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var genericforms = dataManager.GenericFormRepository.Get();
            return Ok(genericforms);
        }

        [HttpDelete]
        public IActionResult DeleteForm(Guid id)
        {
            dataManager.GenericFormRepository.Delete(id);
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Update(GenericForm genericForm)
        {
            dataManager.GenericFormRepository.Update(genericForm);
            return Ok();
        }


        [HttpPost("Add")]
        public IActionResult Add(GenericForm genericForm)
        {
            dataManager.GenericFormRepository.Add(genericForm);
            return Ok();
        }
    }
}
