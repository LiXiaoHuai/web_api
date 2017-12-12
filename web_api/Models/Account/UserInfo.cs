using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api.Models.Other;

namespace web_api.Models.Account
{
    public class UserInfo: ResultData
    {
        public string Account { get; set; }
        public string NikeName { get; set; }
        public string CreateDateTime { get; set; }
    }
}