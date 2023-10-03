using BlazorApp2.Server.Domain;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RowController : Controller
    {
        private readonly DataManager dataManager;

        public RowController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var rows = dataManager.RowRepository.Get(id);
            return Ok(rows);
        }

        [HttpPut]
        public IActionResult Update(Row row)
        {
            dataManager.RowRepository.Update(row);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Row row)
        {
            dataManager.RowRepository.Add(row);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            dataManager.RowRepository.Delete(id);
            return Ok();
        }
    }
}
