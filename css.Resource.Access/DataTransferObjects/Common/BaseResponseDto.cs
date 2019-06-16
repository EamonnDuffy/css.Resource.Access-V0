namespace css.Resource.Access.DataTransferObjects.Common
{
    public class BaseResponseDto
    {
        public int HttpStatusCode { get; set; }

        public DeveloperCode DeveloperCode { get; set; }

        public string DeveloperMessage { get; set; }

        public long GeneratedInMs { get; set; }
    }
}
