//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mgmt.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class wh_dep_locations
    {
        public int id { get; set; }
        public int id_wh_dep { get; set; }
        public string name { get; set; }
    
        public virtual wh_dep wh_dep { get; set; }
    }
}
