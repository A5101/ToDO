# BlazorApp2 or "How to do your ToDo"
Начнем с того, что же такое Blazor?

Blazor — это технология, позволяющая создавать клиентские веб-приложения с использованием C# и .NET, а не JavaScript.

Была поставлена задача: используя Blazor, реализовать простенький CRUD проект для работы с задачами.
Для начала необходимо определить с сущностью задачи.
```c#
/// <summary>
/// Класс, представляющий элемент списка дел.
/// </summary>
public class ToDoElement
{
    /// <summary>
    /// Уникальный идентификатор элемента списка дел.
    /// </summary>
    [Required]
    public Guid Id { get; set; }

    /// <summary>
    /// Создает новый экземпляр класса ToDoElement.
    /// При создании автоматически устанавливает текущую дату в качестве даты добавления.
    /// </summary>
    public ToDoElement() => DateAdded = DateTime.Now;

    /// <summary>
    /// Заголовок элемента списка дел.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Описание элемента списка дел.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Флаг, указывающий, завершен ли элемент списка дел.
    /// </summary>
    public bool IsComplete { get; set; }

    /// <summary>
    /// Дата добавления элемента в список дел.
    /// </summary>
    public DateTime DateAdded { get; set; }

    /// <summary>
    /// Дата завершения элемента списка дел (если задача завершена).
    /// </summary>
    public DateTime? DateCompleted { get; set; }
}
```
## Создание новых задач
### Клинтская часть
Blazor позволяет писать код на стороне клиента с помощью C# вместо JavaScript. Однако практически всю структуру компонента будет составлять html код. Так как предлагается рассмотреть принципы работы с Blazor, предлагаю рассмотреть особенность, с которой начат текущий подраздел, на практике.

Для добавления возможности создания новой задачи, сначала определим текстовые поля для соответсвующих атрибутов сущности задачи. Blazor дает возможность связать наши поля ввода с полями в части @code с помощью использования @bind. Таким образом, обращаясь в коде к этим полям, Blazor даст нам содержимое привязанных к ним html элементов.
```html
<...>
<input required type="text" class="form-control" placeholder="Your ToDo title" @bind=toDoTitle @oninput="OnTitleInput" />
<...>
<textarea class="form-control" rows="2" @bind=toDoDescription></textarea>
<...>
<button class="btn btn-primary ms-auto" data-bs-dismiss="modal" @onclick="AddToDo">
<...>
```
```c#
@code {
    private List<ToDoElement> toDoList = new List<ToDoElement>();
    private string? toDoTitle = string.Empty;
    private string? toDoDescription = string.Empty;
    private bool showButton = false;

    private async void AddToDo()
    {
        if (!string.IsNullOrWhiteSpace(toDoTitle))
        {
            await client.PostAsJsonAsync<ToDoElement>("api/ToDo/", new ToDoElement() { Title = toDoTitle, Description = toDoDescription, Id = Guid.NewGuid() });
            toDoTitle = string.Empty;
            toDoDescription = string.Empty;
            //Thread.Sleep(200);
            await Refresh();
        }

    }   
    private async Task Refresh()
    {
        toDoList = await client.GetFromJsonAsync<List<ToDoElement>>("api/ToDo");
        StateHasChanged();
    }
}
```

Blazor позволяет вставить некоторый элемент в наш компонент используя @inject. Так например вставим HttpClient, чтобы иметь возможность отправлять запросы.
```c#
@inject HttpClient client
```

Отдельно стоит отметить часть
```c#
await client.PostAsJsonAsync<ToDoElement>("api/ToDo/", new ToDoElement() { Title = toDoTitle, Description = toDoDescription, Id = Guid.NewGuid() });
```

Можно заметить, что новую задачу мы отправлем куда-то на сервер, однако для подробного понимания стоит рассмотреть серверную часть, которая будет принимать данный запрос.

### Серверная часть
```c#
[Route("api/[controller]")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly DataManager dataManager;

        public ToDoController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        
        [HttpPost]
        public IActionResult Add(ToDoElement toDoElement)
        {
            dataManager.toDoElementRepository.Add(toDoElement);
            return Ok();
        }
```
По сути, используя [Route("api/[controller]")] мы явно указали, как попасть к данному контроллеру, а также явно указали, какие действия контроллера какие Http запросы будут обрабатывать. Так, действие Add() будет обрабатывать все Post запросы к данному контроллеру.

Вернемся к отправке данных из компонента. Используя HttpClient client, мы отправляем Post запрос, содержащий созданную задачу в JSON-формате, на сервер. Сервер, получив новую задачу, проводит с ней заданные действия, в данном случае вызывает метод Add хранилища задач, что приведет к сохранению нашей задачи в БД.
```c#
await client.PostAsJsonAsync<ToDoElement>("api/ToDo/", new ToDoElement() { Title = toDoTitle, Description = toDoDescription, Id = Guid.NewGuid() });
```

## Получение списка задач
Похожим образом происходит получение задач. Просим у сервера в виде Get запроса задач, соотвествующее действие контроллера находит запрашиваемые данные и возвращает обратно клиенту для вывода.
```c#
toDoList = await client.GetFromJsonAsync<List<ToDoElement>>("api/ToDo");
```
```c#
[HttpGet]
        public IActionResult Get()
        {
            var toDOs = dataManager.toDoElementRepository.Get();
            return Ok(toDOs);
        }
```

## Заключение
На примерах были рассмотрены некоторые принципы работы с компонентами Blazor. Описали некоторую структуру странички, попробовали использовать @bind для связи значений, назначали методы из блока @code на события html элементов, рассмотрели общий принцип отправки запросов на сервер.
