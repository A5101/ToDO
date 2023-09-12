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

    [HttpPut]
    public IActionResult CreateForm(Form form)
    {
        dataManager.FormRepository.Add(form);

        return Ok(form); 
    }
    
    [HttpGet]
    public IActionResult GetForms()
    {
        var forms = dataManager.FormRepository.GetFormsTemplates();
        return Ok(forms);
    }
    [HttpDelete]
    public IActionResult DeleteForm(Guid id)
    {
         dataManager.FormRepository.Delete(id);
        return Ok();
    }

}
