//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LookTechnoCMS.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActivityLog
    {
        public int Id { get; set; }
        public int ActivityLogTypeId { get; set; }
        public int UserId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    }
}
