//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YazilimSinamaStarsUpPlanner.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Durumlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Durumlar()
        {
            this.GorevDurumları = new HashSet<GorevDurumları>();
        }
    
        public int DurumId { get; set; }
        public string DurumAdi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GorevDurumları> GorevDurumları { get; set; }
    }
}