using System;
using System.Runtime.Serialization;

namespace Shared.Exceptions
{
    [Serializable]
    public class EstimateIsNull : Exception
    {
        protected EstimateIsNull(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EstimateIsNull() : base("Given estimate is null") { }
    }
}
