//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace accomtest
{
    using System;
    using System.Collections.Generic;
    
    public partial class CalcTarrifHeaderTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CalcTarrifHeaderTbl()
        {
            this.CalcRateTbls = new HashSet<CalcRateTbl>();
            this.CalcTariffTbls = new HashSet<CalcTariffTbl>();
        }
    
        public short CalLawId { get; set; }
        public decimal TrfHCode { get; set; }
        public byte TrfType { get; set; }
        public string TrfName { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
    
        public virtual CalcLawTbl CalcLawTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CalcRateTbl> CalcRateTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CalcTariffTbl> CalcTariffTbls { get; set; }
    }
}