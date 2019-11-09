using Basic.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Core.Interfaces
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Podaje ilość obiektów
        /// </summary>
        List<T> MembersCount(List<T> list);
    }
}
