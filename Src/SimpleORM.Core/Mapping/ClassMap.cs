using System;
using System.Collections.Generic;

namespace SimpleORM.Core.Mapping
{
    /// <summary>
    /// Represents the metadata of a class
    /// </summary>
    public class ClassMap
    {

        public Type TheType { get; private set; }

        public IList<PropertyMap> Properties { get; private set; }
        
        public IdentifierMap Identifier { get; private set; }

        public ClassMap(Type type, IdentifierMap identifier, IList<PropertyMap> properties)
        {
            TheType = type;
            Identifier = identifier;
            Properties = properties;
        }
    }
}