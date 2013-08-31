using System;

namespace Labs.Pubquiz.Domain.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string format, params object[] paramters)
            : base(string.Format(format, paramters))
        {
        }
    }
}