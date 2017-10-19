using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Authorization
{
    public interface ILoginManager
    {
        /// <summary>
        /// 用于检查是否登陆成功,解析当前
        /// </summary>
        /// <returns></returns>
        bool IsLogin();
    }

    public class LoginManager : ILoginManager
    {
        public bool IsLogin()
        {
            //1：检查缓存是否有数据
            
            //2：通过api来确认是否正常登陆
            return true;
        }
    }
}
