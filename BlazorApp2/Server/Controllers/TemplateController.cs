using BlazorApp2.Server.Domain;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : Controller
    {
        private readonly DataManager dataManager;

        public TemplateController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var toDOs = dataManager.TemplateRepository.Get();
            return Ok(toDOs);
        }

        [HttpPut]
        public IActionResult Update(Template template)
        {
            dataManager.TemplateRepository.Update(template);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Template template)
        {
            dataManager.TemplateRepository.Add(template);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            dataManager.TemplateRepository.Delete(id);
            return Ok();
        }
    }
}
