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
    
    public partial class wh_dep
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public wh_dep()
        {
            this.wh_dep_locations = new HashSet<wh_dep_locations>();
        }
    
        public int id { get; set; }
        public int id_wh { get; set; }
        public string dep_name { get; set; }
    
        public virtual wh_list wh_list { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wh_dep_locations> wh_dep_locations { get; set; }
    }
}
