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
    
    public partial class tCouponDetail
    {
        public int CouponDetailID { get; set; }
        public int CouponID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public int DiscountTypeID { get; set; }
        public Nullable<int> PercentageDiscount { get; set; }
        public Nullable<decimal> AmountOff { get; set; }
    
        public virtual tCoupon tCoupon { get; set; }
        public virtual tDiscountType tDiscountType { get; set; }
        public virtual tProduct tProduct { get; set; }
    }
}
