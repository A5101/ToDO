using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
    public class GenericForm
    {
        public Guid Id { get; set; }
        public string? JsonText { get; set; } //Серилизованный объект

        public string? ClassName { get; set; }

        public object GetDeserializeData(Type type)
        {
            return JsonSerializer.Deserialize(JsonText, type);
        }
        public void SetSerializeData<T>(T data)
        {
            JsonText = JsonSerializer.Serialize(data);
        }
    }
}
