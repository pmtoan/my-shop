//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Management_Book
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchase
    {
        public int purchase_id { get; set; }
        public Nullable<double> total { get; set; }
        public Nullable<System.DateTime> create_at { get; set; }
        public Nullable<int> customer_id { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<double> profit { get; set; }
    }
}
