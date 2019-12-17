/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：OwinDemo.Middleware
* 类 名 称：InspectionMiddleware
* 创建日期：2019/12/17 11:34:18
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：InspectionMiddleware
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
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using Microsoft.Owin;
using OwinDemo.Attributes;
using OwinDemo.Models;

namespace OwinDemo.Middleware
{
    public class InspectionMiddleware : MiddlewareBase
    {
        public InspectionMiddleware(OwinMiddleware next, MainWindow main)
            :base(next, main)
        {

        }
        [Get("musicPlay")]
        public void MusicPlay()
        {
            HttpResult<MusicModel> httpResult = new HttpResult<MusicModel>();
            this.ActionJson(httpResult);
        }
        [Get("musicStop")]
        public void MusicStop()
        {
            this.ActionJson(new HttpResult<MusicModel>());
        }
        [Get("screenPlay")]
        public void ScreenPlay()
        {
            this.main.Dispaly(true);
            this.ActionJson(new HttpResult<ScreenModel>());
        }
        [Get("screenStop")]
        public void ScreenStop()
        {
            this.main.Dispaly(false);
            this.ActionJson(new HttpResult<ScreenModel>());
        }
    }
}
