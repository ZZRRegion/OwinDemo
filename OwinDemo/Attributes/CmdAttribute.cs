/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：OwinDemo.Attributes
* 类 名 称：CmdAttribute
* 创建日期：2019/12/17 16:53:52
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：CmdAttribute
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
    public class CmdAttribute:Attribute
    {
        public string Type { get; set; }
        public CmdAttribute(string type)
        {
            this.Type = type;
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
