/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：OwinDemo
* 类 名 称：RApp
* 创建日期：2019/12/17 11:29:43
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：RApp
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.Windows.Controls;
namespace OwinDemo
{
    public class RApp
    {
        public MainWindow Main { get; private set; }
        public RApp(MainWindow main)
        {
            this.Main = main;
        }
        public void Run()
        {
            StartOptions options = new StartOptions();
            options.Urls.Add("http://*:12345");
            WebApp.Start(options, this.Startup);
        }
        private void Startup(IAppBuilder app)
        {
            app.Use<Middleware.HomeMiddleware>(this.Main);
            app.Use<Middleware.InspectionMiddleware>(this.Main);
            app.Use<Middleware.LogMiddleware>(this.Main);
            app.Use<Middleware.PCMiddleware>(this.Main);
            app.Run(context => {
                context.Response.ContentType = "text/plain;charset=utf-8";
                context.Response.Write($"未找到路径：{context.Request.Uri}");
                return Task.FromResult(0);
            });
        }
        #region 构造函数
        #endregion
        #region Variables
        #endregion
        #region private Variables
        #endregion
        #region Methods
        #endregion
        #region private Methods
        #endregion
        #region Event
        #endregion
    }
}
