using System;
using css.Resource.Access.DataAccess.EntityFramework.Entities.Access;
using log4net;
using System.Reflection;
using css.Resource.Access.DataTransferObjects.Common;
using css.Resource.Access.Validation;
using Microsoft.AspNetCore.Http;

namespace css.Resource.Access.BusinessEngines
{
    public interface ISessionsBusinessEngine
    {
        SessionEntity Create(string credentialsType, string credentialsValue, string credentialsPassword);
    }

    public class SessionsBusinessEngine : BaseBusinessEngine, ISessionsBusinessEngine
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SessionEntity Create(string credentialsType, string credentialsValue, string credentialsPassword)
        {
            SessionEntity sessionEntity = null;

            Guard.NotNullOrWhiteSpace(credentialsType, StatusCodes.Status400BadRequest, DeveloperCode.InvalidData, "Invalid CredentialsType.");
            Guard.NotNullOrWhiteSpace(credentialsValue, StatusCodes.Status400BadRequest, DeveloperCode.InvalidData, "Invalid CredentialsValue.");
            Guard.NotNullOrWhiteSpace(credentialsPassword, StatusCodes.Status400BadRequest, DeveloperCode.InvalidData, "Invalid CredentialsPassword.");

            // TODO: Implement Database Layer.

            if ((credentialsType == "E-Mail") && (credentialsValue == "Does.Not.Exist@Resource.css") &&
                (credentialsPassword == "Password1"))
            {
                var nowUtc = DateTime.UtcNow;

                sessionEntity = new SessionEntity()
                {
                    SessionId = 0,
                    SessionKey = Guid.NewGuid().ToString(),
                    CreatedDateTimeUtc = nowUtc,
                    LastAccessedDateTimeUtc = nowUtc
                };
            }

            return sessionEntity;
        }
    }
}
