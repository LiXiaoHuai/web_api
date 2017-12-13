using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models.Blog
{
    public class SavePostData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Img { get; set; }
    }
}