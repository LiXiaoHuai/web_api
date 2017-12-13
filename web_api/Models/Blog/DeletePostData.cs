using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models.Blog
{
    public class DeletePostData
    {
        public string UserId { get; set; }
        public string BlogId { get; set; }
    }
}