using System;
using System.Runtime.Serialization;

namespace Shared.Exceptions
{
    [Serializable]
    public class EstimateNotComplete : Exception
    {
        protected EstimateNotComplete(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EstimateNotComplete() : base("Provided request isn't complete (missing object parameters)") { }
    }
}
