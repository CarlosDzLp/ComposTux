using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComposTux.ViewModels
{
    public class BaseResult<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
        public int Count { get; set; }
    }
}