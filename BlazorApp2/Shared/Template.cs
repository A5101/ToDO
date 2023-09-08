using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
    public class Template
    {
        public int MarginLeft { get; set; }

        public int MarginTop { get; set;}

        public int Width { get; set; }

        public int Height { get; set; }

        public string? Type {  get; set; }

        public string? Name { get; set; }

        public Guid TargetFrom { get; set; }

        public Guid TargetTo { get; set; }

        public Guid Id { get; set; }
 
    }
}
