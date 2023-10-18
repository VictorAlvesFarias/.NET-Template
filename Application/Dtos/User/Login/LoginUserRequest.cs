using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.User.Login
{
    public class LoginUserRequest
    {
        public string AccessKey { get; set; }
        public string Password { get; set; }    
    }
}
