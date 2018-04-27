using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal.Domain.Model
{
    public class UserLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserInfoModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
