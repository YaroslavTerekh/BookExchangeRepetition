using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchange.Domain.AuthModels
{
    public class AuthUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
