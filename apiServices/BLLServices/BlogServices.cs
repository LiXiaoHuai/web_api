using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork;

namespace apiServices.BLLServices
{
    public class BlogServices: BaseService
    {
        #region 根据获添加或修改博客信息
        public bool Save(Blog m, out string  msg)
        {
            bool result = false;
            msg = string.Empty;
            try
            {
                var o = db.Blog.Where(c => c.Id == m.Id).FirstOrDefault();
                if(o == null)
                {
                    m.Id = Tools.GetGuid();
                    m.CreateDateTime = DateTime.Now;
                    db.Blog.Add(m);
                }
                else
                {
                    o.Img = m.Img;
                    o.Details = m.Details;
                    o.Title = m.Title;
                }
                result = db.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return result;
        }

        #endregion




        #region 根据获取博客id删除记录
        public bool Delete (string id ,out string msg)
        {
            bool result = false;
            msg = string.Empty;
            try
            {
                var o = db.Blog.Where(c => c.Id == id).FirstOrDefault();
                if(o == null)
                {
                    msg = "找不到该记录";
                    return result;
                }
                db.Blog.Remove(o);
                result = db.SaveChanges() > 0; 
            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
            return result;
        }

        #endregion
    }
}
