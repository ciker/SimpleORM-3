using System;
using System.Reflection;

namespace SimpleORM.Core.Mapping
{
    /// <summary>
    /// PropertyMap represents the metadata of a single property
    /// </summary>
    public class PropertyMap
    {
        public PropertyInfo TheProperty { get; private set; }
        public string Name { get; private set; }
        public Type Type { get; private set; }

        public PropertyMap(PropertyInfo propertyInfo, string name, Type propertyType)
        {
            TheProperty = propertyInfo;
            Name = name;
            Type = propertyType;
        }
    }
}