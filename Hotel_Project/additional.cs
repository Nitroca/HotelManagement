//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel_Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class additional
    {
        public int Additional_ID { get; set; }
        public Nullable<int> Booking_ID { get; set; }
        public Nullable<int> Service_ID { get; set; }
        public Nullable<int> Extra_ID { get; set; }
        public Nullable<decimal> Additional_Price { get; set; }
        public string Additional_Info { get; set; }
    
        public virtual booking booking { get; set; }
        public virtual extra extra { get; set; }
        public virtual service service { get; set; }
    }
}
