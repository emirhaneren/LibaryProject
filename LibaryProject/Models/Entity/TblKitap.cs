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
    
    public partial class TblKitap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblKitap()
        {
            this.TblHareket = new HashSet<TblHareket>();
        }
    
        public int ID { get; set; }
        public string Ad { get; set; }
        public Nullable<byte> Kategori { get; set; }
        public Nullable<int> Yazar { get; set; }
        public string BasımYılı { get; set; }
        public string YayınEvi { get; set; }
        public string SayfaSayısı { get; set; }
        public Nullable<bool> Durum { get; set; }
        public string KitapResim { get; set; }
        public string Detay { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblHareket> TblHareket { get; set; }
        public virtual TblKategori TblKategori { get; set; }
        public virtual TblYazar TblYazar { get; set; }
    }
}
