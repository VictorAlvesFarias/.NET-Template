using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitites
{
    public class BaseEntityUserRelation : BaseEntity
    {
        public ApplicationUser User { get; private set; }
        public string UserId { get; private set; }
        public void SetUser(string _userId)
        {
            UserId = _userId;
        }
    }
}
