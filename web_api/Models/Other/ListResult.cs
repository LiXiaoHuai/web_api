using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models.Other
{
    public class ListResult
    {
        public string pageIndex { get; set; }
        public string pageSize { get; set; }
        public string totalPage { get; set; }
        public string totalCount { get; set; }
    }
}