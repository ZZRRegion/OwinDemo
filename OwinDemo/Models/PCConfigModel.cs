/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：OwinDemo.Models
* 类 名 称：PCConfigModel
* 创建日期：2019/12/17 18:23:57
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：PCConfigModel
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
using System.Reflection;

using System.Windows.Controls;
namespace OwinDemo.Models
{
    public class PCConfigModel
    {
        public string Ip { get; set; }
        public string Port { get; set; }
        private PCConfigModel()
        {

        }
        public static PCConfigModel Create(string result)
        {
            if (!string.IsNullOrWhiteSpace(result))
            {
                string[] items = result.Split('&');
                if(items.Length >= 2)
                {
                    PCConfigModel model = new PCConfigModel();
                    PropertyInfo[] pis = model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach(string item in items)
                    {
                        string[] values = item.Split('=');
                        foreach(PropertyInfo pi in pis)
                        {
                            if(pi.Name.ToLower() == values[0].ToLower())
                            {
                                pi.SetValue(model, values[1]);
                                break;
                            }
                        }
                    }
                    return model;
                }
            }
            return null;
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
