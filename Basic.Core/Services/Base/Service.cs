using Basic.Core.Interfaces;
using Basic.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Core.Services
{
    public class Service<T> : IBaseService<T>
    {
        public virtual string Hello()
        {
            return "Hello from BaseService :)";
        }

        public virtual List<T> MembersCount(List<T> list)
        {
            return list;
        }
    }
}
