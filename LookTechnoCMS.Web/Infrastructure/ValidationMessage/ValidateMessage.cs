using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Web.Infrastructure.ValidationMessage
{
    [Serializable]
    public class ValidateMessage
    {

        public string Title { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
        public bool IsSticky { get; set; }
      
        


    }
}