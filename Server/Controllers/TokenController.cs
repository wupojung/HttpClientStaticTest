using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtHelpers jwt;
        private IHttpContextAccessor _httpContextAccessor;

        public TokenController(JwtHelpers jwt, IHttpContextAccessor httpContextAccessor)
        {
            this.jwt = jwt;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet, Route("")]
        public IActionResult Index()
        {
            Random rnd = new Random();

            return Ok(jwt.GenerateToken(rnd.Next(10000).ToString()));
        }

        [HttpGet, Route("check")]
        public IActionResult Check()
        {

            var accessToken = _httpContextAccessor.HttpContext.GetTokenAsync("access_token").Result;
            var token = new JwtSecurityToken(accessToken);
            string nameid = token.Claims.Where(c => c.Type == "nameid")
                          .Select(x => x.Value).FirstOrDefault();

            return Ok(nameid);
        }
    }
}