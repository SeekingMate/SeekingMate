using FreesomeShared;
using Microsoft.AspNetCore.Mvc;

namespace FreesomeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/<UserController>/loginCredential
        [HttpGet("{loginCredential}")]
        public User Get(string loginCredential)
        {
            return new User();
        }

        // POST api/<UserController>/Login
        [HttpPost("Login")]
        public string Login([FromServices] ServerData data, [FromBody] UserControllerLoginParameters Parameters)
        {
            if (string.IsNullOrEmpty(Parameters.AccessCodeHashed) || string.IsNullOrEmpty(Parameters.PassphraseHashed))
                return null;

            var existingUser = data.Users.FirstOrDefault(u => u.AccessCodeHash == Parameters.AccessCodeHashed);
            if (existingUser != null)
            {
                if (existingUser.PassphraseHash == Parameters.PassphraseHashed)
                    return existingUser.LoginCredential;
                else return null;
            }
            else
            {
                var newUser = new User()
                {
                    AccessCodeHash = Parameters.AccessCodeHashed,
                    PassphraseHash = Parameters.PassphraseHashed,
                    LoginCredential = (Parameters.AccessCodeHashed + Parameters.PassphraseHashed).GetHashString()
                };
                data.Users.Add(newUser);
                return newUser.LoginCredential;
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
