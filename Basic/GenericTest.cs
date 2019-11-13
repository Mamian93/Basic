using System;
using System.Collections.Generic;
using System.Text;

namespace Basic
{
    public class GenericTest<T> where T : class
    {
        private readonly Type classType;
        public GenericTest()
        {
            classType = typeof(T);
        }
        public T TransformObject(T model)
        {
            var instance = Activator.CreateInstance(classType);
            var modelProperties = instance.GetType().GetProperties();
            foreach (var prop in modelProperties)
            {
                if (prop.CanWrite && prop.CanRead)
                {
                    var value = prop.GetValue(model);
                    prop.SetValue(instance, value);
                }
            }

            return (T)Convert.ChangeType(instance, typeof(T));
        }

        //One level of copy
        //public static T CopyTo<T>(this T source, T target)
        //{
        //    foreach (var prop in source.GetType().GetProperties())
        //    {
        //        if (prop.CanRead && prop.CanWrite)
        //            prop.SetValue(target, prop.GetValue(source));
        //    }
        //    return source;
        //}

    }
}

