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
    
    public partial class vCouponDetailsCurrentlyOpen
    {
        public int CouponDetailID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public int CouponID { get; set; }
        public int DiscountTypeID { get; set; }
        public Nullable<decimal> AmountOff { get; set; }
        public Nullable<int> PercentageDiscount { get; set; }
        public string DiscountType { get; set; }
        public Nullable<bool> IsFree { get; set; }
        public Nullable<bool> IsBOGO { get; set; }
        public Nullable<bool> IsPercentageDiscount { get; set; }
        public Nullable<long> isAmountOff { get; set; }
    }
}
