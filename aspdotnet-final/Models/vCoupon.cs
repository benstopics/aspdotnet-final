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
    
    public partial class vCoupon
    {
        public int CouponID { get; set; }
        public string Coupon { get; set; }
        public string Description { get; set; }
        public int CouponSourceID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> ThroughDate { get; set; }
    }
}
