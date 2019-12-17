/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：OwinDemo
* 类 名 称：Util
* 创建日期：2019/12/17 14:05:53
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：Util
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
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
namespace OwinDemo
{
    public static class Util
    {
        /// <summary>
        /// 转json
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string ToJson(this object @this)
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializerSettings settings = new System.Runtime.Serialization.Json.DataContractJsonSerializerSettings();
            settings.DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("yyyy-MM-dd HH:mm:ss");
            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(@this.GetType(), settings);
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, @this);
            byte[] bys = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(bys);
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
