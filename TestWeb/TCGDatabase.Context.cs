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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TCGEntities : DbContext
    {
        public TCGEntities()
            : base("name=TCGEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TCG_MASTER_INS_BRG> TCG_MASTER_INS_BRG { get; set; }
        public virtual DbSet<TCG_MASTER_MERK_BRG> TCG_MASTER_MERK_BRG { get; set; }
        public virtual DbSet<TCG_MASTER_SUPPLIER_BARANG> TCG_MASTER_SUPPLIER_BARANG { get; set; }
        public virtual DbSet<TCG_MASTER_TYPE_BRG> TCG_MASTER_TYPE_BRG { get; set; }
        public virtual DbSet<TCG_MASTER_UKURAN> TCG_MASTER_UKURAN { get; set; }
        public virtual DbSet<TCG_D_BARANG_MASUK> TCG_D_BARANG_MASUK { get; set; }
        public virtual DbSet<TCG_H_BARANG_MASUK> TCG_H_BARANG_MASUK { get; set; }
        public virtual DbSet<TCG_MASTER_CABANG> TCG_MASTER_CABANG { get; set; }
        public virtual DbSet<TCG_DATA_BARANG> TCG_DATA_BARANG { get; set; }
    }
}
