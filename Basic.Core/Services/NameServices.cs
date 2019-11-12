using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Core.Services
{
    public class NameServices
    {
        public NameServices(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
