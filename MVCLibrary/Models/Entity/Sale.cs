//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCLibrary.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public int SaleID { get; set; }
        public Nullable<int> Book { get; set; }
        public Nullable<int> Member { get; set; }
        public Nullable<byte> Staff { get; set; }
        public Nullable<System.DateTime> AcquisitionDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
    
        public virtual Book Book1 { get; set; }
        public virtual Member Member1 { get; set; }
        public virtual Penalty Penalty { get; set; }
        public virtual Staff Staff1 { get; set; }
    }
}
