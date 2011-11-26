using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimpleORM.Core.Mapping
{
    /// <summary>
    /// ClassMapper is responsible to generate the metadata for a given type to be used
    /// later in the persistence process.
    /// </summary>
    public class ClassMapper : IClassMapper
    {
        private const string DefaultIdentifier = "Id";

        /// <summary>
        /// Generates the ClassMap based on the given type
        /// </summary>
        /// <param name="type">The Type to map</param>
        /// <returns>The map containing the metadata for the type</returns>
        public ClassMap Map(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("Type cannot be null");
            }

            PropertyInfo[] properties = type.GetProperties();
            if (properties == null || properties.Length == 0)
            {
                throw new MappingException("An entity must have properties to map");
            }

            return new ClassMap(type, MapIdentifier(properties), MapProperties(properties));
        }

        private IdentifierMap MapIdentifier(PropertyInfo[] properties)
        {
            PropertyInfo id = properties.Where(x => x.Name.Equals(DefaultIdentifier)).FirstOrDefault();

            if (id == null)
            {
                throw new MappingException("Entity does not contain an identifier [Id].");
            }

            return new IdentifierMap(id, id.Name, id.PropertyType);
        }

        private IList<PropertyMap> MapProperties(PropertyInfo[] properties)
        {
            IList<PropertyMap> mappedProperties = new List<PropertyMap>();
            foreach (var propertyInfo in properties)
            {
                if (!propertyInfo.Name.Equals(DefaultIdentifier))
                {
                    var mappedProperty = new PropertyMap(propertyInfo, propertyInfo.Name, propertyInfo.PropertyType);
                    mappedProperties.Add(mappedProperty);
                }
            }

            return mappedProperties;
        }
    }
}
