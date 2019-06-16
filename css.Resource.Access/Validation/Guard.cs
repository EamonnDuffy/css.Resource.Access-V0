using System.Reflection;
using css.Resource.Access.DataTransferObjects.Common;
using log4net;

namespace css.Resource.Access.Validation
{
    public static class Guard
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void NotNull<TValue>(TValue actualValue, int httpStatusCode, DeveloperCode developerCode, string developerMessage)
        {
            if (actualValue == null)
                throw new GuardException(httpStatusCode, developerCode, developerMessage);
        }

        public static void NotNullOrWhiteSpace(string actualValue, int httpStatusCode, DeveloperCode developerCode, string developerMessage)
        {
            if (string.IsNullOrWhiteSpace(actualValue))
                throw new GuardException(httpStatusCode, developerCode, developerMessage);
        }
    }
}
