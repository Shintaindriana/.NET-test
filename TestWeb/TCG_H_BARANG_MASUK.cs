//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class TCG_H_BARANG_MASUK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TCG_H_BARANG_MASUK()
        {
            this.TCG_D_BARANG_MASUK = new HashSet<TCG_D_BARANG_MASUK>();
        }
    
        public string KD_TRANSAKSI { get; set; }
        public Nullable<System.DateTime> TGL_TRANSAKSI { get; set; }
        public string KODE_CABANG { get; set; }
        public string KODE_SUPPLIER { get; set; }
        public string KETERANGAN { get; set; }
        public Nullable<int> JUMLAH_BARANG { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCG_D_BARANG_MASUK> TCG_D_BARANG_MASUK { get; set; }
        public virtual TCG_MASTER_CABANG TCG_MASTER_CABANG { get; set; }
    }
}
