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
    
    public partial class TCG_D_BARANG_MASUK
    {
        public int PKID { get; set; }
        public string KD_TRANSAKSI { get; set; }
        public string KODE_BARANG { get; set; }
        public Nullable<int> ID { get; set; }
        public string KODE_JENIS { get; set; }
        public string KODE_MERK { get; set; }
        public string KODE_SUPPLIER { get; set; }
        public string KODE_UKURAN { get; set; }
        public string KODE_TYPE { get; set; }
        public string KODE_CABANG { get; set; }
        public Nullable<decimal> HARGA_BELI { get; set; }
        public Nullable<int> JUMLAH_BARANG { get; set; }
        public string STATUS { get; set; }
        public string KETERANGAN { get; set; }
    
        public virtual TCG_H_BARANG_MASUK TCG_H_BARANG_MASUK { get; set; }
        public virtual TCG_MASTER_CABANG TCG_MASTER_CABANG { get; set; }
        public virtual TCG_MASTER_INS_BRG TCG_MASTER_INS_BRG { get; set; }
        public virtual TCG_MASTER_MERK_BRG TCG_MASTER_MERK_BRG { get; set; }
        public virtual TCG_MASTER_SUPPLIER_BARANG TCG_MASTER_SUPPLIER_BARANG { get; set; }
        public virtual TCG_MASTER_TYPE_BRG TCG_MASTER_TYPE_BRG { get; set; }
        public virtual TCG_MASTER_UKURAN TCG_MASTER_UKURAN { get; set; }
        public virtual TCG_DATA_BARANG TCG_DATA_BARANG { get; set; }
    }
}
