//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibaryProject.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblHareket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblHareket()
        {
            this.TblCezalar = new HashSet<TblCezalar>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Kitap { get; set; }
        public Nullable<int> Uye { get; set; }
        public Nullable<byte> Personel { get; set; }
        public Nullable<System.DateTime> AlisTarih { get; set; }
        public Nullable<System.DateTime> IadeTarih { get; set; }
        public Nullable<bool> IslemDurum { get; set; }
        public Nullable<System.DateTime> UyeGetirTarih { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblCezalar> TblCezalar { get; set; }
        public virtual TblKitap TblKitap { get; set; }
        public virtual TblPersonel TblPersonel { get; set; }
        public virtual TblUyeler TblUyeler { get; set; }
    }
}
