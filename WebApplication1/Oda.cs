//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Oda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oda()
        {
            this.Misafirler = new HashSet<Misafirler>();
        }
    
        public int OdaId { get; set; }
        public string OdaNumarasi { get; set; }
        public string Yatak_Sayisi { get; set; }
        public int BinaId { get; set; }
    
        public virtual Bina Bina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Misafirler> Misafirler { get; set; }
    }
}
