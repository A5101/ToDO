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
    //public class Element
    //{
    //    public Guid Id { get; set; }
    //    public string Value
    //    {
    //        get
    //        {
    //            var dic = (Dictionary<string, string>)JsonSerializer.Deserialize(Properties, typeof(Dictionary<string, string>));
    //            return dic["Text"];
    //        }
    //        set
    //        {
    //            var dic = (Dictionary<string, string>)JsonSerializer.Deserialize(Properties, typeof(Dictionary<string, string>));
    //            dic["Text"] = value;
    //            Properties = JsonSerializer.Serialize(dic, typeof(Dictionary<string, string>));
    //        }
    //    }
    //    public string ComboBoxOptions { get; set; }

    //    public string Properties { get; set; }

    //    public string Type { get; set; }

    //    public Element()
    //    {

    //        var dictionary = new Dictionary<string, string>();
    //        dictionary.Add("font-size", "2ex");
    //        dictionary.Add("width", "50px");
    //        dictionary.Add("heigth", "50px");
    //        dictionary.Add("margin-right", "0px");
    //        dictionary.Add("margin-top", "0px");
    //        dictionary.Add("margin-bottom", "0px");
    //        dictionary.Add("margin-left", "0px");
    //        dictionary.Add("Text", "");
    //        dictionary.Add("Checked", "false");
    //        dictionary.Add("Mask", "");

    //        var optionsDic = new Dictionary<string, string>();
    //        optionsDic.Add(Guid.NewGuid().ToString(), "Sanya");
    //        optionsDic.Add(Guid.NewGuid().ToString(), "Lesha");

    //        ComboBoxOptions = JsonSerializer.Serialize(optionsDic, typeof(Dictionary<string, string>)); ;
    //        Properties = JsonSerializer.Serialize(dictionary, typeof(Dictionary<string, string>));
    //    }

    //    public Dictionary<string, string> GetProperties()
    //    {
    //        return (Dictionary<string, string>)JsonSerializer.Deserialize(Properties, typeof(Dictionary<string, string>));
    //    }

    //    public void SetProperties(Dictionary<string, string> dic)
    //    {
    //        Properties = JsonSerializer.Serialize(dic, typeof(Dictionary<string, string>));
    //    }

    //    public Dictionary<string, string> GetOptions()
    //    {
    //        return (Dictionary<string, string>)JsonSerializer.Deserialize(ComboBoxOptions, typeof(Dictionary<string, string>));
    //    }
    //    public void SetOptions(Dictionary<string, string> dic)
    //    {
    //        ComboBoxOptions = JsonSerializer.Serialize(dic, typeof(Dictionary<string, string>));
    //    }

    //}

    public class Element : Template
    {
        public Guid Id { get; set; }

        public string Text { get; set; }
    }
}
