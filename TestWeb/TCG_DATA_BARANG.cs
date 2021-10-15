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
    
    public partial class TCG_DATA_BARANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TCG_DATA_BARANG()
        {
            this.TCG_D_BARANG_MASUK = new HashSet<TCG_D_BARANG_MASUK>();
        }
    
        public string KD_BARANG { get; set; }
        public Nullable<int> ID { get; set; }
        public string KODE_JENIS { get; set; }
        public string KODE_MERK { get; set; }
        public string KODE_SUPPLIER { get; set; }
        public string KODE_UKURAN { get; set; }
        public string KODE_CABANG { get; set; }
        public string KODE_TYPE { get; set; }
        public string NAMA_BARANG { get; set; }
        public string SERI { get; set; }
        public string ITEM { get; set; }
        public Nullable<decimal> HARGA_SUPPLIER { get; set; }
        public Nullable<decimal> HARGA_JUAL_SUPPLIER { get; set; }
        public Nullable<decimal> HARGA_JUAL_TCG { get; set; }
        public Nullable<int> STOK_BARANG { get; set; }
        public string KETERANGAN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCG_D_BARANG_MASUK> TCG_D_BARANG_MASUK { get; set; }
        public virtual TCG_MASTER_INS_BRG TCG_MASTER_INS_BRG { get; set; }
        public virtual TCG_MASTER_MERK_BRG TCG_MASTER_MERK_BRG { get; set; }
        public virtual TCG_MASTER_SUPPLIER_BARANG TCG_MASTER_SUPPLIER_BARANG { get; set; }
        public virtual TCG_MASTER_TYPE_BRG TCG_MASTER_TYPE_BRG { get; set; }
        public virtual TCG_MASTER_UKURAN TCG_MASTER_UKURAN { get; set; }
    }
}