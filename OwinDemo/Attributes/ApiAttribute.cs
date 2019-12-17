/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：OwinDemo.Attributes
* 类 名 称：ApiAttribute
* 创建日期：2019/12/17 14:27:31
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：ApiAttribute
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
namespace OwinDemo.Attributes
{
    public class ApiAttribute : Attribute
    {
        public string Api { get; set; }
        public ApiAttribute(string api)
        {
            this.Api = api;
        }
    }
    public class GetAttribute : ApiAttribute
    {
        public GetAttribute(string api)
            :base(api)
        {
        }
    }
    public class PostAttribute : ApiAttribute
    {
        public PostAttribute(string api)
            :base(api)
        {
        }
    }
}
