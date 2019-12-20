/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：OwinDemo.Middleware
* 类 名 称：HomeMiddleware
* 创建日期：2019/12/20 17:01:11
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：HomeMiddleware
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
    public class HomeMiddleware : MiddlewareBase
    {
        public HomeMiddleware(OwinMiddleware next, MainWindow main) : base(next, main)
        {
        }
        public void Test()
        {
            this.ActionContent("Test");
        }
    }
}
