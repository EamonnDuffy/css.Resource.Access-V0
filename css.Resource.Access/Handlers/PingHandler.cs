using System.Reflection;
using System.Threading;
using css.Resource.Access.DataTransferObjects.Common;
using css.Resource.Access.WebApi;
using log4net;
using Microsoft.AspNetCore.Http;

namespace css.Resource.Access.Handlers
{
    public interface IPingHandler
    {
        ApiResponse<PingResponseDto> Ping();
    }

    public class PingHandler : BaseHandler, IPingHandler
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ApiResponse<PingResponseDto> Ping()
        {
            return Execute(nameof(Ping), () =>
            {
                Thread.Sleep(1000);

                var responseDto = new PingResponseDto()
                {
                    HttpStatusCode = StatusCodes.Status200OK,
                    DeveloperCode = DeveloperCode.Success,
                    DeveloperMessage = "Success."
                };

                var apiResponse = new ApiResponse<PingResponseDto>(responseDto);

                return apiResponse;
            });
        }
    }
}
