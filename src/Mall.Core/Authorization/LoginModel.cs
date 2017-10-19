using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Authorization
{
    public class LoginModel
    {
        public string Account { get; set; }

        public string Password { get; set; }

        public bool IsRemember { get; set; }
    }
}
