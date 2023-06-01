using BlazorAuthenticationJwtNet6.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAuthenticationJwtNet6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Login(UserLoginDto request) 
        {
            string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVGVzdCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlRlc3QifQ.nJ_-Dt8fG-SGlu5OvAAJn3Z30Yguq_Y6yhznNvECsaTuP3JAC0FRUotbm2ZIx8YxMtfpDFagDFs125-Ul7QGpA";
            return token;

        }

    }
}
