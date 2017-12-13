using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models.Account
{
    public class RegisterPostData
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string NikeName { get; set; }
    }
}