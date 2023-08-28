using BlazorApp2.Server.Domain;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementController : Controller
    {
        private readonly DataManager dataManager;

        public ElementController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var toDOs = dataManager.ElementRepository.Get();
            return Ok(toDOs);
        }

        [HttpPut]
        public IActionResult Update(Element element)
        {
            dataManager.ElementRepository.Update(element);
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(Element element)
        {
            dataManager.ElementRepository.Add(element);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            dataManager.ElementRepository.Delete(id);
            return Ok();
        }
    }
}
