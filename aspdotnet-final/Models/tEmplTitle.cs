//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace aspdotnet_final.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tEmplTitle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tEmplTitle()
        {
            this.tEmpls = new HashSet<tEmpl>();
        }
    
        public int EmplTitleID { get; set; }
        public string EmplTitle { get; set; }
        public bool IsStoreManager { get; set; }
        public bool IsSelfScan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tEmpl> tEmpls { get; set; }
    }
}
