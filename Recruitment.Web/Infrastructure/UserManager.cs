using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruitment.Web.Infrastructure
{
    public class UserManager
    {
        public static bool Authenticated { get; set; }
        public static int UserId { get; set; }
    }
}