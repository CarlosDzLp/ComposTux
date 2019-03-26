using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComposTux.ViewModels
{
    public class TokenRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
    public class TokenValidate
    {
        public string Token { get; set; }
        public string Expired { get; set; }
        public DateTime Date { get; set; }
    }
}