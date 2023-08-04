using BlazorApp2.Server.Domain;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly DataManager dataManager;

        public ToDoController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var toDOs = dataManager.toDoElementRepository.Get();
            return Ok(toDOs);
        }

        [HttpPost]
        public IActionResult Add(ToDoElement toDoElement)
        {
            dataManager.toDoElementRepository.Add(toDoElement);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            dataManager.toDoElementRepository.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDate(ToDoElement toDoElement)
        {
            dataManager.toDoElementRepository.Update(toDoElement);
            return Ok();
        }
    }
}
