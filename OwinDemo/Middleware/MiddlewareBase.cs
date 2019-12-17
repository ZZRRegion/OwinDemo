/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：OwinDemo.Middleware
* 类 名 称：MiddlewareBase
* 创建日期：2019/12/17 13:58:43
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：MiddlewareBase
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using System.Windows.Controls;
using OwinDemo.Attributes;
using System.IO;
using System.Web;

namespace OwinDemo.Middleware
{
    public class MiddlewareBase : OwinMiddleware
    {
        protected readonly MainWindow main;
        protected IOwinContext context;

        public MiddlewareBase(OwinMiddleware next, MainWindow main)
            :base(next)
        {
            this.main = main;
        }
        protected virtual bool ToHandle(string url, IOwinContext context)
        {
            MethodInfo[] methods = this.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach(MethodInfo mi in methods)
            {
                ApiAttribute api = null;
                switch (context.Request.Method)
                {
                    case "GET":
                        api = mi.GetCustomAttribute<GetAttribute>();
                        break;
                    case "POST":
                        api = mi.GetCustomAttribute<PostAttribute>();
                        break;
                }
                if(api != null && api.Api.ToLower() == url.ToLower())
                {
                    mi.Invoke(this, null);
                    return true;
                }
            }
            return false;
        }
        public override Task Invoke(IOwinContext context)
        {
            this.context = context;
            string localurl = context.Request.Uri.LocalPath.ToString();
            this.main.AddRecord(localurl);
            RLog.Add(localurl);
            localurl = localurl.Remove(0, 1);
            if (this.ToHandle(localurl, context))//当前中间件已处理，直接返回
            {
                return Task.FromResult(0);
            }
            return this.Next.Invoke(context);
        }
        protected void ActionFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                this.context.Response.ContentType = MimeMapping.GetMimeMapping(fileName);
                ///设置文件名
                this.context.Response.Headers.Add("Content-Disposition", new string[] { $"attachment;filename={Path.GetFileName(fileName)}" });
                byte[] bys = new byte[1024];
                FileStream fs = File.OpenRead(fileName);
                int len = fs.Read(bys, 0, bys.Length);
                while(len > 0)
                {
                    this.context.Response.Write(bys, 0, len);
                    len = fs.Read(bys, 0, bys.Length);
                }
                fs.Close();
            }
            else
            {
                this.context.Response.ContentType = "text/plain";
                this.context.Response.Write("文件不存在！");
            }
        }
        protected void ActionJson(object sender)
        {
            this.context.Response.ContentType = "application/json;charset=utf-8";
            this.context.Response.Write(sender.ToJson());
        }
    }
}
