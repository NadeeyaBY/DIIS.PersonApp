namespace DIIS.PersonApp.Models
{
    public class TokenInfo
    {
        //{ "access_token":"xx","expires_in":3600,"token_type":"Bearer","scope":"profile","refresh_token":"yyyy"}
        public string? access_token { get; set; }
        public string? expires_in { get; set; }
        public string? token_type { get; set; }
        public string? scope { get; set; }
        public string? refresh_token { get; set; }
    }
}
