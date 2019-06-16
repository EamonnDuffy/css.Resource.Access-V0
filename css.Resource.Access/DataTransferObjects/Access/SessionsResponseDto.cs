using css.Resource.Access.DataTransferObjects.Common;

namespace css.Resource.Access.DataTransferObjects.Access
{
    public class SessionsResponseDto : BaseResponseDto
    {
        public long SessionId { get; set; }

        public string SessionKey { get; set; }
    }
}
