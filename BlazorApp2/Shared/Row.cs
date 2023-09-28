using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{


    public class Row
    {
        public Element? Element { get; set; }
        public Guid Id { get; set; }

    }
}
