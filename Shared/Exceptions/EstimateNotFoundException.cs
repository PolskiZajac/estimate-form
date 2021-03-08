using System;
using System.Runtime.Serialization;

namespace Shared.Exceptions
{
    [Serializable]
    public class EstimateNotFoundException : Exception
    {
        protected EstimateNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EstimateNotFoundException(int id) : base($"Couldn't find estimate with id={id}") { }
    }
}
