namespace css.Resource.Access.DataTransferObjects.Access
{
    public class SessionsRequestDto
    {
        // ["E-Mail" | "UserName" | "MobilePhoneNumber"]
        public string CredentialsType { get; set; }

        public string CredentialsValue { get; set; }

        public string CredentialsPassword { get; set; }
    }
}
