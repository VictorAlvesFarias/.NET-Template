using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.User.Create
{
    public class CreateUserRequest
    {
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordConfirm { get; set; }
        public string Password { get; set; }    
    }
}
