using css.Resource.Access.DataTransferObjects.Access;
using css.Resource.Access.WebApi;
using log4net;
using System.Reflection;
using css.Resource.Access.BusinessEngines;
using css.Resource.Access.DataTransferObjects.Common;
using css.Resource.Access.Validation;
using Microsoft.AspNetCore.Http;

namespace css.Resource.Access.Handlers
{
    public interface ISessionsHandler
    {
        ApiResponse<SessionsResponseDto> Create(SessionsRequestDto requestDto);
    }

    public class SessionsHandler : BaseHandler, ISessionsHandler
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private ISessionsBusinessEngine SessionsBusinessEngine { get; }

        public SessionsHandler(ISessionsBusinessEngine sessionsBusinessEngine)
        {
            SessionsBusinessEngine = sessionsBusinessEngine;
        }

        public ApiResponse<SessionsResponseDto> Create(SessionsRequestDto requestDto)
        {
            return Execute(nameof(Create), () =>
            {
                Guard.NotNull(requestDto, StatusCodes.Status400BadRequest, DeveloperCode.InvalidData, "RequestDto is null.");

                var sessionEntity = SessionsBusinessEngine.Create(requestDto.CredentialsType, requestDto.CredentialsValue, requestDto.CredentialsPassword);

                SessionsResponseDto responseDto = null;

                if (sessionEntity == null)
                {
                    responseDto = new SessionsResponseDto()
                    {
                        HttpStatusCode = StatusCodes.Status400BadRequest,
                        DeveloperCode = DeveloperCode.InvalidData,
                        DeveloperMessage = "Invalid Data."
                    };
                }
                else
                {
                    responseDto = new SessionsResponseDto()
                    {
                        HttpStatusCode = StatusCodes.Status200OK,
                        DeveloperCode = DeveloperCode.Success,
                        DeveloperMessage = "Success.",
                        SessionId = sessionEntity.SessionId,
                        SessionKey = sessionEntity.SessionKey
                    };
                }

                var apiResponse = new ApiResponse<SessionsResponseDto>(responseDto);

                return apiResponse;
            });
        }
    }
}
