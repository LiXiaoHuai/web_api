using apiServices.BLLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiServices
{
    public class GBLLService: IDisposable
    {
        private myproEntities1 _DbContext = null;
        public myproEntities1 DbContext { get { return _DbContext; } }

        public GBLLService(myproEntities1 db)
        {
            _DbContext = db;
        }

        public void Dispose()
        {
            if (DbContext != null) DbContext.Dispose();
        }
        public BlogServices BlogServices { get { var o = new BlogServices(); o.BLLService = this; return o; } }
        public CarouslService CarouslService { get { var o = new CarouslService(); o.BLLService = this; return o; } }
        public AccountServices AccountServices { get { var o = new AccountServices(); o.BLLService = this; return o; } }
    }
}
