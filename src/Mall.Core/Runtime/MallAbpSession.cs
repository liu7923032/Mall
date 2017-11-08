using System;
using System.Collections.Generic;
using System.Text;
using Abp.Runtime.Session;

namespace Mall.Runtime
{
    public static class MallAbpSession
    {
        public static int GetUserId(this IAbpSession abpSession)
        {
            if(abpSession.UserId == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(abpSession.UserId);
            }
        }
    }
}
