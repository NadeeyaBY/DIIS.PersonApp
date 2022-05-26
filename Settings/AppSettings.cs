namespace DIIS.PersonApp.Settings
{
    public class OAuthSetting
    {
        public string? OAuthBaseAddress { get; set; }
        public string? OAuthRedirectUri { get; set; }
        public string? OAuthClientID { get; set; }
        public string? OAuthClientSecret { get; set; }
        public string? OAuthState { get; set; }
    }

    public class FileUploadSetting
    {
        public string? FilePathTemp { get; set; }
        public long FileMaxSize { get; set; }
        public string? FilePathPrivate { get; set; }
        public string? FilePathPublic { get; set; }
    }
}
