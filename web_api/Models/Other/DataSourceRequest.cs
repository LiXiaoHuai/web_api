using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models.Other
{
    public class DataSourceRequest
    {
        public string page { get; set; }

        public string rows { get; set; }

        public string sidx { get; set; }

        public string isDesc { get; set; }
    }
}