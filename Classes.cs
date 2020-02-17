using System;
using System.Collections.Generic;
using System.Text;

namespace Jameson
{
    public class Item
    {
        public string name { get; set; }
        public string address { get; set; }
        public int type { get; set; }
        public int flors { get; set; }
        public string login { get; set; }
        public int group { get; set; }
        public List<object> phones { get; set; }
        
    }

    public class D
    {
        public List<Item> items { get; set; }
    }

    public class RootObject
    {
        public string Q { get; set; }
        public D D { get; set; }
    }
}
