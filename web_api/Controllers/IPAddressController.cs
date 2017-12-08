using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web_api.Models;

namespace web_api.Controllers
{
    public class IPAddressController : ApiController
    {
        private static IList<Address> address = new List<Address>()
        {
            new Address(){ IPAdress="1.91.38.31", Province="北京市", City="北京市" },
            new Address(){ IPAdress = "210.75.225.254", Province = "上海市", City = "上海市"  },
        };

        public IEnumerable<Address> GetIPAddresses()
        {
            return address;
        }

        public Address GetIPAddressByIP(string IP)
        {
            return address.FirstOrDefault(x => x.IPAdress == IP);
        }
    }
}