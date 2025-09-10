using System;

namespace SCAE.Framework.Exceptions
{
    public class BadRequestException : Exception
    {
     
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
