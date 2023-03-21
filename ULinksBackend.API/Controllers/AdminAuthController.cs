using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsefulLinksBackend;
using UsefulLinksBackend.Models;

namespace ULinksBackend.API.Controllers;


[Route("api/authAdmin")]
[ApiController]
public class AdminAuthController : ControllerBase
{
    
    
    [HttpPost]
    public async Task<Dictionary<string, string>> Post([FromBody]AuthDataDto data)
    {
        if (data.Login == Storage.Login && data.Password == Storage.Password)
        {
            //Storage.Token = Guid.NewGuid().ToString();
            Storage.Token = "7a5c6826-4f56-4514-b4e6-bfa8ca63e2b6";
            
            return new Dictionary<string, string>() { { "token", Storage.Token } };
        }
        else
        {
            return new Dictionary<string, string>() { { "token", "" } };
        }
        
    }
    
    
    
    [HttpPut]
    public async Task<Dictionary<string, string>> ChangePassword([FromBody]ChangePasswordDto data)
    {
        if (data.Login == Storage.Login && data.Password == Storage.Password)
        {
            Storage.ComputeAndSetToken(data.Login, data.NewPassword);
            return new Dictionary<string, string>() { { "token", Storage.Token } };
        }
        else
        {
            return new Dictionary<string, string>() { { "token", "" } };
        }
        
    }
    
}