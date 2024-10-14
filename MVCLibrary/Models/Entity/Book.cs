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
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Sale = new HashSet<Sale>();
        }
    
        public int BookID { get; set; }
        public string Name { get; set; }
        public Nullable<byte> Category { get; set; }
        public Nullable<int> Author { get; set; }
        public string PublicationYear { get; set; }
        public string PublishingHouse { get; set; }
        public string Page { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual Author Author1 { get; set; }
        public virtual Category Category1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
