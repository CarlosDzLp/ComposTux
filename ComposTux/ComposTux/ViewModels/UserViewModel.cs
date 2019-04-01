using ComposTux.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComposTux.ViewModels
{
    public class UserViewModel : User 
    {
        public string playerId { get; set; }
        public string pushToken { get; set; }
    }
}