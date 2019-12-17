/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：OwinDemo.Middleware
* 类 名 称：LogMiddleware
* 创建日期：2019/12/17 15:03:57
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：LogMiddleware
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using Microsoft.Owin;
using OwinDemo.Attributes;

namespace OwinDemo.Middleware
{
    public class LogMiddleware : MiddlewareBase
    {
        public LogMiddleware(OwinMiddleware next, MainWindow main) : base(next, main)
        {
        }
        [Get("log")]
        public void Log()
        {
            this.ActionFile(RLog.LogFile);
        }
        [Get("happy")]
        public void Redirect()
        {
            this.context.Response.Redirect("http://www.ruijie.com.cn/");
        }
    }
}
