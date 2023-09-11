using BlazorApp2.Server.Domain;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Form")]
public class FormController : ControllerBase
{
    private readonly DataManager dataManager;

    public FormController(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    // Добавление новой формы
    [HttpPut]
    public IActionResult CreateForm(Form form)
    {
        // Добавьте валидацию и обработку ошибок по вашему усмотрению

        dataManager.FormRepository.Add(form);
        

        return Ok(form); // Можете вернуть Id созданной формы или ее данные
    }

    // Получение списка форм
    [HttpGet]
    public IActionResult GetForms()
    {
        var forms = dataManager.FormRepository.GetForms();
        return Ok(forms);
    }

    //// Получение формы по Id
    //[HttpGet("{id}")]
    //public IActionResult GetForm(Guid id)
    //{
    //    var form = _context.Forms.FirstOrDefault(f => f.Id == id);
    //    if (form == null)
    //    {
    //        return NotFound();
    //    }

    //    return Ok(form);
    //}

    //// Обновление формы
    //[HttpPost("{id}")]
    //public IActionResult UpdateForm(Guid id, Form updatedForm)
    //{
    //    var form = _context.Forms.FirstOrDefault(f => f.Id == id);
    //    if (form == null)
    //    {
    //        return NotFound();
    //    }

    //    // Обновите свойства формы на основе updatedForm

    //    _context.SaveChanges();

    //    return Ok(form);
    //}

    //// Удаление формы
    //[HttpDelete("{id}")]
    //public IActionResult DeleteForm(Guid id)
    //{
    //    var form = _context.Forms.FirstOrDefault(f => f.Id == id);
    //    if (form == null)
    //    {
    //        return NotFound();
    //    }

    //    _context.Forms.Remove(form);
    //    _context.SaveChanges();

    //    return NoContent();
    //}
}
