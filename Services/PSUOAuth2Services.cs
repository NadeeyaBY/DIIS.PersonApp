using DIIS.PersonApp.IServices;
using DIIS.PersonApp.Models;
using DIIS.PersonApp.Settings;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DIIS.PersonApp.Services
{
    public class PSUOAuth2Services : IPSUOAuth2Services
    {
        public HttpClient _httpClient { get; }
        public OAuthSetting _OAuthSetting { get; }



        public PSUOAuth2Services(HttpClient httpClient,
            IOptions<OAuthSetting> OAuthSetting)
        {
            _httpClient = httpClient;
            _OAuthSetting = OAuthSetting.Value;

        }
        public string CallAuthorize()
        {
            var ru = new RequestUrl(_OAuthSetting.OAuthBaseAddress + "?oauth=authorize");
            //var ru = new RequestUrl(_appSettings.OAuthBaseAddress + "?oauth=authorize&remember=true");
            var OAuthRedirectUri = _OAuthSetting.OAuthRedirectUri;
            var ClientId = _OAuthSetting.OAuthClientID;

            var url = ru.CreateAuthorizeUrl(
                clientId: ClientId,
                responseType: "code",
                redirectUri: OAuthRedirectUri,
                //state: "docs", 
                state: _OAuthSetting.OAuthState
                //scope: "dev_guideline"
                );
            return url;
        }

        public async Task<TokenInfo> CallTokenAsync(string code)
        {
            var OAuthRedirectUri = _OAuthSetting.OAuthRedirectUri;
            var ClientId = _OAuthSetting.OAuthClientID;
            var ClientSecret = _OAuthSetting.OAuthClientSecret;

            var response = await _httpClient.RequestTokenAsync(new TokenRequest
            {
                Address = _OAuthSetting.OAuthBaseAddress + "?oauth=token",
                GrantType = "authorization_code",
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                Parameters =
            {
                { "response_type" , "code" },
                { "code", code },
                { "redirect_uri", OAuthRedirectUri },
            }
            });

            TokenInfo tokenInfo = JsonConvert.DeserializeObject<TokenInfo>(response.Json.ToString());


            return tokenInfo;
        }


        public async Task<bool> SignOut()
        {
            bool result = false;
            //var ClientId = _appSettings.OAuthClientID;
            //var TokenInfo = await _localStorageProtected.GetItemAsync<TokenInfo>("AInfo");
            //if (TokenInfo == null)
            //{
            //    result = false;
            //}
            //else
            //{
            //    var accessToken = TokenInfo.access_token;
            //    var response = await _httpClient.RevokeTokenAsync(new TokenRevocationRequest
            //    {
            //        Address = _appSettings.OAuthBaseAddress + "?oauth=revoke",
            //        ClientId = ClientId,
            //        Token = accessToken
            //    });

            //    var revokeInfo = JsonConvert.DeserializeObject<RevokeInfo>(response.Json.ToString());
            //    await _httpClient.GetAsync(_appSettings.OAuthBaseAddress + "?oauth=revoke_session");
            //    result = revokeInfo.revoked;
            //}

            //await _localStorageProtected.RemoveItemAsync("AInfo");
            //await _localStorageProtected.RemoveItemAsync("ExpireTime");

            return result;
        }

        private class RevokeInfo
        {
            public bool revoked { get; set; }
        }


        public async Task<User> GetProfileByAccessTokenAsync(string accessToken)
        {
            var response = await _httpClient.GetUserInfoAsync(new UserInfoRequest
            {
                Address = _OAuthSetting.OAuthBaseAddress + "?oauth=me",
                Token = accessToken,
            });
            User user = JsonConvert.DeserializeObject<User>(response.Json.ToString());

            return user;
        }

    }


}
