/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：OwinDemo.Middleware
* 类 名 称：PCMiddleware
* 创建日期：2019/12/17 16:31:59
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：PCMiddleware
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using Microsoft.Owin;
using OwinDemo.Attributes;
using OwinDemo.Models;

namespace OwinDemo.Middleware
{
    public class PCMiddleware : MiddlewareBase
    {
        [DllImport("user32.dll")]
        private static extern int ExitWindowsEx(int uFlags, int dwReserved);
        public PCMiddleware(OwinMiddleware next, MainWindow main) : base(next, main)
        {
        }
        [Method("Logout")]
        public void Logout()
        {
            this.ActionJson(new HttpResult<PCModel>());
            ExitWindowsEx(0, 0);//注销计算机
        }
        [Method("Config", MethodType.Post)]
        public void Config()
        {
            string contentType = this.context.Request.ContentType;
            StreamReader sr = new StreamReader(this.context.Request.Body);
            string result = sr.ReadToEnd();
            sr.Close();
            PCConfigModel model = PCConfigModel.Create(result);
            Console.WriteLine(result);
            this.ActionJson(model);
        }
    }
}
