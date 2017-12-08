using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace web_api.Models.Other
{
    public enum AjaxStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        [DescriptionAttribute("成功")]
        SUCCESS = 0,
        /// <summary>
        /// 错误
        /// </summary>
        [DescriptionAttribute("错误")]
        ERROR = 1,
        /// <summary>
        /// 未登录
        /// </summary>
        [DescriptionAttribute("未登录")]
        NOLOGIN = 2,
        /// <summary>
        /// 没有权限
        /// </summary>
        [DescriptionAttribute("没有权限")]
        NOPERMISS = 3
    }
}