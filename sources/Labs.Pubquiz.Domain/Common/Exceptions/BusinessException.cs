using System;
using System.Runtime.Serialization;

namespace Labs.Pubquiz.Domain.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string format, params object[] paramters)
            : base(string.Format(format, paramters))
        {
        }

        public BusinessException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}