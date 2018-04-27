using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace portalDemo.Models
{
    [Serializable]
    public class CurrentUserModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }

    }
    public class SendCodeModel
    {
        public string telenum { get; set; }
    }
}