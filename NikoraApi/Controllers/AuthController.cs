using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NikoraApi.Core.Repository;
using NikoraApi.Domain.Models;
using NikoraApi.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NikoraApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        public AuthController(IMapper mapper, IUserRepository userRepository, IConfiguration config)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _config = config;
        }
        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            var user = _mapper.Map<User>(loginRequest);
            var res = await LoginAsync(user);
            return res.Success ? Ok(res) : BadRequest(res.Message);
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        #region private methods

        private async Task<LoginResponseDto> LoginAsync(User user)
        {
            var validUser = _userRepository.CheckValidUser(user);
            if (validUser == null) return new LoginResponseDto() { Success = false, Message = "Invalid UserName/Password" };


            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, validUser.Id.ToString() ),
                new Claim(ClaimTypes.Name, validUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, validUser.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, validUser.Id.ToString() ),
            };

            //  var roles = await _userManager.GetRolesAsync(user);

            //var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x));
            //claims.AddRange(roleClaims);



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("ApiKey")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(30);

            var token = new JwtSecurityToken
                (
                   issuer: "https://localhost:7030",
                   audience: "https://localhost:7030",
                   claims: claims,
                   expires: expires,
                   signingCredentials: creds
                );

            return new LoginResponseDto()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Message = "Login Successful!",
                UserName = validUser.UserName,
                Success = true,
                UserId = validUser.Id
            };

        }


        #endregion

    }
}
