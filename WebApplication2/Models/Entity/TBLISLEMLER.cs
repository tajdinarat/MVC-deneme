//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLISLEMLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLISLEMLER()
        {
            this.TBLKITAPLARs = new HashSet<TBLKITAPLAR>();
        }
    
        public int islemID { get; set; }
        public Nullable<int> islemKisi { get; set; }
        public Nullable<System.DateTime> islemTarih { get; set; }
    
        public virtual TBLKISILER TBLKISILER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLKITAPLAR> TBLKITAPLARs { get; set; }
    }
}
