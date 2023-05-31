using System.Security.Claims;
using System.Text.Json;

namespace BlazorAuthenticationJwtNet6.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

        //idk but for jwt need next fields : {"http:///schemas.xmlsoap.org/ws/2005/05/identity/claims/name": "Test", "http:///schemas.microsoft.com/ws/2008/06/identity/claims/role": "Test"
        //thi is correct : eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVGVzdCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlRlc3QifQ.nJ_-Dt8fG-SGlu5OvAAJn3Z30Yguq_Y6yhznNvECsaTuP3JAC0FRUotbm2ZIx8YxMtfpDFagDFs125-Ul7QGpA
        // //eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVGVzdCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJUZXN0In0.yTEuL9xUfTN_g4WNicC6TP2UvgXx2f7Hcv1Skp2Z9krhROl2FVkyzGSZGb5V2SgBd2VY3fTy2ooWl9cJOCFBjw
        string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVGVzdCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlRlc3QifQ.nJ_-Dt8fG-SGlu5OvAAJn3Z30Yguq_Y6yhznNvECsaTuP3JAC0FRUotbm2ZIx8YxMtfpDFagDFs125-Ul7QGpA";
            //var identity = new ClaimsIdentity(); // user not auth if bracket empty 
            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token),"jwt"); 
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
