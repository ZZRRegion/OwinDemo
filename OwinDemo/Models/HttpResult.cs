/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：OwinDemo.Models
* 类 名 称：HttpResult
* 创建日期：2019/12/17 13:32:45
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：HttpResult
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
namespace OwinDemo.Models
{
    public class HttpResult<T> where T: ModelBase,new()
    {
        public bool State { get; set; } = true;
        public string Reason { get; set; }
        
        public DateTime DateTime { get; set; } = DateTime.Now;
        public T Value { get; set; } = new T();
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
