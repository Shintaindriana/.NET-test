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
    
    public partial class TCG_MASTER_SUPPLIER_BARANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TCG_MASTER_SUPPLIER_BARANG()
        {
            this.TCG_D_BARANG_MASUK = new HashSet<TCG_D_BARANG_MASUK>();
            this.TCG_DATA_BARANG = new HashSet<TCG_DATA_BARANG>();
        }
    
        public string KODE_SUPPLIER { get; set; }
        public string NAMA_SUPPLIER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCG_D_BARANG_MASUK> TCG_D_BARANG_MASUK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCG_DATA_BARANG> TCG_DATA_BARANG { get; set; }
    }
}
