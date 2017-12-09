﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web_api.Models.Carousel;

namespace web_api.Controllers
{
    public class CarousController : BaseController
    {
        #region 获取轮播
        public CarouslListResult GetCarouslList()
        {
            var Result = new CarouslListResult();
            var list = new List<CarouslListResult.Carousel>();
            var o = db.Carousel.ToList();
            o.ForEach(c =>
            {
                list.Add(new CarouslListResult.Carousel
                {
                    img = c.Img,
                    src = c.Scr
                });
            });
            Result.CarouselList = list;
            return Result;
        }


        #endregion
    }
}