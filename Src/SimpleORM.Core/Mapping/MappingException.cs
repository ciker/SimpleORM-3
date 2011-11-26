using System;

namespace SimpleORM.Core.Mapping
{
    public class MappingException : Exception
    {
        public MappingException(string message) : base(message)
        {
            
        }
    }
}