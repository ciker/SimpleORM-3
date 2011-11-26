using System;

namespace SimpleORM.Core.Mapping
{
    /// <summary>
    /// ClassMapper is responsible to generate the metadata for a given type to be used
    /// later in the persistence process.
    /// </summary>
    public interface IClassMapper
    {
        /// <summary>
        /// Generates the ClassMap based on the given type
        /// </summary>
        /// <param name="type">The Type to map</param>
        /// <returns>The map containing the metadata for the type</returns>
        ClassMap Map(Type type);
    }
}