using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CrossLayersUtils.Utils.Reflections
{
    public static class PropertiesInjection
    {
        private static Dictionary<string, Dictionary<PropertyInfo, ConstructorInfo>> _constructorsCache = new Dictionary<string, Dictionary<PropertyInfo, ConstructorInfo>>();

        public static void InjectInstanceOf(this object obj,Type propertiesType, params  object[] constructorArgs)
        {
            var constructorArgsTypes = (constructorArgs == null || constructorArgs.Length == 0) ? Type.EmptyTypes :
                constructorArgs.Select(arg => arg.GetType()).ToArray();

            var objKey = String.Join(obj.GetType().FullName,  constructorArgs.Select(a=>a.GetType().FullName));
            lock (_constructorsCache)//thread safe
            {
                if (!_constructorsCache.ContainsKey(objKey))
                {
                    //find the matching properties
                    var objMatchedPropertiesTemp = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(p => p.PropertyType.GetConstructor(constructorArgsTypes) != null)
                            .ToDictionary(x => x, x => x.PropertyType.GetConstructor(constructorArgsTypes));

                    _constructorsCache.Add(objKey, objMatchedPropertiesTemp);
                }
            }
          

            var objMatchedProperties = _constructorsCache[objKey];

            //invoke constructors
            objMatchedProperties.Keys.ToList().ForEach(key => {
                key.SetValue(obj, objMatchedProperties[key].Invoke(constructorArgs), null);
            });
        }

        
    }
}
