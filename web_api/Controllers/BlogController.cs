using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using apiServices;
using CommonFrameWork;
using web_api.Models.Blog;
using web_api.Models.Other;

namespace web_api.Controllers
{
    public class BlogController : BaseController
    {
        #region 获取博客列表
        public BlogListResult GetBlogList(string page,string rows)
        {
            var result = new BlogListResult();
            var list = new List<Blog>();
            var data = new List<BlogListResult.Blog>();
            var isDesc = true;
            var _page = string.IsNullOrEmpty(page)?1:int.Parse(page);
            var _rows = string.IsNullOrEmpty(rows)?3:int.Parse(rows);
            var q = db.Blog.AsQueryable();
            list = Tools.PagedIQueryable<Blog, DateTime?>(q, _page, _rows, isDesc, a => a.CreateDateTime).ToList();
      
            result.pageIndex = page.ToString();
            result.pageSize = rows.ToString();
            result.totalPage = ((q.Count() / _rows) + 1).ToString();
            result.totalCount = q.Count().ToString();

            list.ForEach(c =>
            {
                string Details = c.Details;
                //使用正则表达式 把html标签代码，替换成 纯文本显示

                string Content = Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Details, @"(?m)<script[^>]*>(\w|\W)*?</script[^>]*>", "", RegexOptions.Multiline | RegexOptions.IgnoreCase), @"(?m)<style[^>]*>(\w|\W)*?</style[^>]*>", "", RegexOptions.Multiline | RegexOptions.IgnoreCase), @"(?m)<select[^>]*>(\w|\W)*?</select[^>]*>", "", RegexOptions.Multiline | RegexOptions.IgnoreCase), @"(?m)<a[^>]*>(\w|\W)*?</a[^>]*>", "", RegexOptions.Multiline | RegexOptions.IgnoreCase), "(<[^>]+?>)| ", "", RegexOptions.Multiline | RegexOptions.IgnoreCase), @"(\s)+", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                if (Content.Length > 150)
                {
                    Content = Content.Substring(0, 50) + "....";
                }

                string Title = c.Title;
          
                if (Title.Length > 19)
                {
                    Title = Title.Substring(0, 19) + "....";
                }

                data.Add(new BlogListResult.Blog
                {
                    id = c.Id,
                    img = c.Img,
                    title = Title,
                    content = Content,
                    createDateTime = Tools.ToDateString(c.CreateDateTime),
                });

            });
            result.blogList = data;
            return result;
        }
        #endregion


        #region 根据获取博客id获取详情
        public BlogDetailResult GetBlogDetail(string id)
        {
            var result = new BlogDetailResult();
            result.success = false;
            var Detail = db.Blog.Where(c => c.Id == id).FirstOrDefault();
            if(Detail == null)
            {
                result.msg = "找不到该数据";
            }
            else
            {
                result.success = true;
                result.msg = "成功";
                result.id = Detail.Id;
                result.img = Detail.Img;
                result.title = Detail.Title;
                result.detail = Detail.Details;
                result.CreateDateTime = Tools.ToDateString(Detail.CreateDateTime);

            }


            return result;
        }
        #endregion

        #region 保存一个博客信息
        public ResultData SaveBlogDetail(string Title, string Details, string Img, string id)
        {
            var result = new ResultData();
            result.success = false;
            var msg = string.Empty;
            Blog blog = null;
            if (string.IsNullOrEmpty(id))
            {
                blog = new Blog();
            }
            else
            {
                blog = db.Blog.Where(c => c.Id == id).FirstOrDefault();
            }
            blog.Img = Img;
            blog.Title = Title;
            blog.Details = Details;

            result.success = BLLService.BlogServices.Save(blog, out msg);
            result.msg = msg;

            return result;
        }

        #endregion




        #region 根据获取博客id删除内容
        public ResultData DeleteBlogForId(string id)
        {
            var result = new ResultData();
            result.success = false;
            var msg = string.Empty;
            result.success = BLLService.BlogServices.Delete(id, out msg);
            result.msg = msg;
            return result;
        }


        #endregion
    }
}