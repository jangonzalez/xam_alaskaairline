using System;
using System.Net;

namespace Services.Exceptions
{
    public class APIErrorException : Exception
    {
        public string ApiError { get; private set; }
        public HttpStatusCode HttpStatusCode { get; private set; }

        public APIErrorException(string error, HttpStatusCode httpStatusCode)
        {
            ApiError = error;
            HttpStatusCode = httpStatusCode;
        }
    }
}
