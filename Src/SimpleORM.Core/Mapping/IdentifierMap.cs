using System;
using System.Reflection;

namespace SimpleORM.Core.Mapping
{
    /// <summary>
    /// KeyMap represents the identifier of an entity, it contains the information
    /// required to create a new identifier for the entity to which it belongs to.
    /// </summary>
    public class IdentifierMap : PropertyMap
    {
        public IdentifierMap(PropertyInfo propertyInfo, string name, Type propertyType) : 
            base(propertyInfo, name, propertyType)
        {
        }
    }
}