using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLib.Utils
{
    public static class ReflectionUtils
    {

        /// <summary>
        /// Find out if a child type implements or inherits from the parent type.
        /// The parent type can be an interface or a concrete class, generic or non-generic.
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static bool InheritsOrImplements(this Type child, Type parent)
        {
            var currentChild = parent.IsGenericTypeDefinition && child.IsGenericType ? child.GetGenericTypeDefinition() : child;

            while (currentChild != typeof(object))
            {
                if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
                    return true;

                currentChild = currentChild.BaseType != null && parent.IsGenericTypeDefinition && currentChild.BaseType.IsGenericType
                                    ? currentChild.BaseType.GetGenericTypeDefinition()
                                    : currentChild.BaseType;

                if (currentChild == null)
                    return false;
            }
            return false;
        }
        private static bool HasAnyInterfaces(Type parent, Type child)
        {
            return child.GetInterfaces().Any(childInterface =>
            {
                var currentInterface = parent.IsGenericTypeDefinition && childInterface.IsGenericType
                    ? childInterface.GetGenericTypeDefinition()
                    : childInterface;

                return currentInterface == parent;
            });

        }
    }

}
