using css.Resource.Access.DataTransferObjects.Common;
using Microsoft.AspNetCore.Mvc;

namespace css.Resource.Access.WebApi
{
    // TODO: REVIEW: Is ApiResponse still required as a separate class?
    public class ApiResponse<TResponseDto> where TResponseDto : BaseResponseDto
    {
        public TResponseDto ResponseDto { get; }

        public ApiResponse(TResponseDto responseDto)
        {
            ResponseDto = responseDto;
        }

        public TResponseDto Prepare(long generatedInMs)
        {
            ResponseDto.GeneratedInMs = generatedInMs;

            return ResponseDto;
        }
    }
}
