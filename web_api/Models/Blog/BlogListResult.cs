using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api.Models.Other;

namespace web_api.Models.Blog
{
    public class BlogListResult: ListResult
    {
        public List<Blog> blogList { get; set; }

        public class Blog
        {
            public string id { get; set; }
            public string title { get; set; }
            public string img { get; set; }
            public string content { get; set; }
            public string createDateTime { get; set; }
        }
    }
}