using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookTechnoCMS.Web.Infrastructure
{
    public enum DeleteResult
    {
        Failed,
        Successded,
        HasConstraints,
        None
    }

    public enum MessageType
    {
        Success,
        Error,
        Info,
        Warnning,
        Warning
    }

    public enum OperationType
    {
        Add,
        Edit,
        Delete
    }

    public enum NetPromoterScore
    {

        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10



    }
    

   

    

 

}
