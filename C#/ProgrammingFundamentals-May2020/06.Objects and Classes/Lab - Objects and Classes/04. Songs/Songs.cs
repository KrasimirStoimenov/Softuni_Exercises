using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Songs
{
    class Songs
    {
        public Songs(string type, string name, string time)
        {
            this.TypeList = type;
            this.Name = name;
            this.Time = time;
        }
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
