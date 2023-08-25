using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
    public class Element
    {
        public string Value { get { return Properties["Text"]; } set { Properties["Text"] = value; } }

        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();

        public string Type { get; set; }

        public Element()
        {
            Properties.Add("width", "50px");
            Properties.Add("heigth", "50px");
            Properties.Add("margin-right", "0px");
            Properties.Add("margin-top", "0px");
            Properties.Add("margin-bottom", "0px");
            Properties.Add("margin-left", "0px");
            Properties.Add("Text", "");
            Properties.Add("Checked", "false");
        }
    }
}
