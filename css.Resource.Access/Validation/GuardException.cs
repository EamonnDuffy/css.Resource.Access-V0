using System;
using css.Resource.Access.DataTransferObjects.Common;

namespace css.Resource.Access.Validation
{
    public class GuardException : Exception
    {
        public int HttpStatusCode { get; }

        public DeveloperCode DeveloperCode { get; }

        public string DeveloperMessage { get; }

        public GuardException(int httpStatusCode, DeveloperCode developerCode, string developerMessage, Exception innerException) : base(developerMessage, innerException)
        {
            HttpStatusCode = httpStatusCode;
            DeveloperCode = developerCode;
            DeveloperMessage = developerMessage;
        }

        public GuardException(int httpStatusCode, DeveloperCode developerCode, string developerMessage) : this(httpStatusCode, developerCode, developerMessage, null)
        {
        }
    }
}
