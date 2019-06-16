using css.Resource.Access.DataTransferObjects.Common;
using css.Resource.Access.Threading;
using css.Resource.Access.WebApi;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace css.Resource.Access.Controllers.api
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private ActionResult<TResponseDto> HandleException<TResponseDto>(string actionName, Exception exception, int httpStatusCode, DeveloperCode developerCode, string developerMessage, long? generatedInMs)
        {
            Log.Error($"Action: {actionName}: Exception.", exception);

            if (generatedInMs == null)
                generatedInMs = AsyncLocalStorage.EndRequest();

            var responseDto = new BaseResponseDto()
            {
                HttpStatusCode = httpStatusCode,
                DeveloperCode = developerCode,
                DeveloperMessage = developerMessage,
                GeneratedInMs = generatedInMs.GetValueOrDefault()
            };

            return StatusCode(httpStatusCode, responseDto);
        }


        protected ActionResult<TResponseDto> Execute<TResponseDto>(string actionName, Func<ApiResponse<TResponseDto>> action) where TResponseDto : BaseResponseDto
        {
            AsyncLocalStorage.BeginRequest();

            ActionResult<TResponseDto> result = default;

            long? generatedInMs = null;

            try
            {
                var apiResponse = action();

#if false
                var zero = 0;
                var uhOh = 1 / zero;
#endif

                generatedInMs = AsyncLocalStorage.EndRequest();

                var responseDto = apiResponse.Prepare(generatedInMs.GetValueOrDefault());

                result = StatusCode(responseDto.HttpStatusCode, responseDto);

#if false
                var zero = 0;
                var uhOh = 2 / zero;
#endif
            }
            catch (Exception exception)
            {
                result = HandleException<TResponseDto>(actionName, exception, StatusCodes.Status500InternalServerError, DeveloperCode.InternalServerError, exception.Message, generatedInMs);
            }

            return result;
        }
    }
}
