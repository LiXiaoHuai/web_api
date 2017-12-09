using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api.Models.Carousel
{
    public class CarouslListResult
    {
        public List<Carousel> CarouselList { get; set; }

        public class Carousel
        {
            public string img { get; set; }
            public string src { get; set; }
        }
    }
}