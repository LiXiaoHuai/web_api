using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api.Models.Other;

namespace web_api.Models.Blog
{
    public class BlogDetailResult: ResultData
    {
        public string id { get; set; }
        public string title { get; set; }
        public string img { get; set; }
        public string CreateDateTime { get; set; }
        public string detail { get; set; }
    }
}