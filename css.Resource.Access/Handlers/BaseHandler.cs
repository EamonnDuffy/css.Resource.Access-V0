using System;
using System.Reflection;
using css.Resource.Access.DataTransferObjects.Common;
using css.Resource.Access.Threading;
using css.Resource.Access.WebApi;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace css.Resource.Access.Handlers
{
    public class BaseHandler
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected ApiResponse<TResponseDto> Execute<TResponseDto>(string actionName, Func<ApiResponse<TResponseDto>> action) where TResponseDto : BaseResponseDto
        {
            ApiResponse<TResponseDto> apiResponse = default;

            try
            {
                apiResponse = action();
            }
            catch (Exception exception)
            {
                // TODO: Implement Logging.

                throw;
            }

            return apiResponse;
        }
    }
}
