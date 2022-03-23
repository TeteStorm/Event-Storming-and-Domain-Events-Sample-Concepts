using System;
using System.Net;

namespace OrderMS.Infrastructure.Exceptions
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, object message = default!)
        {
            Code = code;
            Message = message;
        }

        public HttpStatusCode Code { get; }

        public new object Message { get; }
    }
}