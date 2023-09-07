using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NikoraApi.Domain.Interfaces;
using NikoraApi.Domain.Models;
using NikoraApi.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NikoraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<User> _userRepositoryBase;
        public AuthController(IMapper mapper,IRepositoryBase<User> userRepositoryBase)
        {
            _mapper = mapper;
            _userRepositoryBase = userRepositoryBase;
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
        public void Login([FromBody] LoginRequestDto loginRequest)
        {
            //var user = _mapper.Map<>(loginRequest)
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
    }
}
