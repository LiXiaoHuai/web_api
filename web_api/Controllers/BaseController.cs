﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using apiServices;
using apiServices.BLLServices;
using CommonFrameWork;
using web_api.Models.Other;

namespace web_api.Controllers
{
    public class BaseController : ApiController
    {
        protected myproEntities db
        {
            get
            {
                return BLLService.DbContext;
            }
        }
        protected GBLLService BLLService { get; set; }

        protected JqGridJson jqGrid;
        public BaseController()
        {
            BLLService = new GBLLService(new myproEntities());
        }
       



        public class JqGridJson
        {
            public int page { get; set; }
            public int records { get; set; }
            public int total { get; set; }
            public List<JqgridRow> rows { get; set; }
            public JqGridJson()
            {
                rows = new List<JqgridRow>();
            }

            public class JqgridRow
            {
                public JqgridRow()
                {
                    cell = new List<object>();
                }
                public string id { get; set; }
                public List<object> cell { get; set; }
            }
        }


        public BlogServices AdminServices { get { return BLLService.BlogServices; } }


    }
}