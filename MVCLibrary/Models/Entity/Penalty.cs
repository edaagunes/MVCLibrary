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
    
    public partial class Penalty
    {
        public int PenaltyID { get; set; }
        public Nullable<int> Member { get; set; }
        public Nullable<int> Sale { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<decimal> Money { get; set; }
    
        public virtual Member Member1 { get; set; }
        public virtual Sale Sale1 { get; set; }
    }
}
