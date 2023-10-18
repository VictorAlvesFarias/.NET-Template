
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitites
{
    public class ApplicationUser: IdentityUser
    {
        public DateTime CreateUserDate { get; set; }

        public string Name { get; set; }
    }
}
