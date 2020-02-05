namespace WebApplication6
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BANAN> BANANs { get; set; }
        public virtual DbSet<DATBAN> DATBANs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<MONAN> MONANs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHOMMONAN> NHOMMONANs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THANHTOAN> THANHTOANs { get; set; }
        public virtual DbSet<YEUCAU> YEUCAUs { get; set; }
        public virtual DbSet<DONGTHANHTOAN> DONGTHANHTOANs { get; set; }
        public virtual DbSet<DONGYEUCAU> DONGYEUCAUs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BANAN>()
                .HasMany(e => e.DATBANs)
                .WithRequired(e => e.BANAN)
                .HasForeignKey(e => e.ID_MABAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DATBANs)
                .WithRequired(e => e.KHACHHANG)
                .HasForeignKey(e => e.ID_MAKHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.YEUCAUs)
                .WithRequired(e => e.KHACHHANG)
                .HasForeignKey(e => e.ID_MAKHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONAN>()
                .HasMany(e => e.DONGTHANHTOANs)
                .WithRequired(e => e.MONAN)
                .HasForeignKey(e => e.ID_MAMON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONAN>()
                .HasMany(e => e.DONGYEUCAUs)
                .WithRequired(e => e.MONAN)
                .HasForeignKey(e => e.ID_MAMON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.BANANs)
                .WithRequired(e => e.NHANVIEN)
                .HasForeignKey(e => e.ID_MANHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.THANHTOANs)
                .WithRequired(e => e.NHANVIEN)
                .HasForeignKey(e => e.ID_MANHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHOMMONAN>()
                .HasMany(e => e.MONANs)
                .WithRequired(e => e.NHOMMONAN)
                .HasForeignKey(e => e.ID_MANHOM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THANHTOAN>()
                .HasMany(e => e.DONGTHANHTOANs)
                .WithRequired(e => e.THANHTOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<YEUCAU>()
                .HasMany(e => e.THANHTOANs)
                .WithRequired(e => e.YEUCAU)
                .HasForeignKey(e => e.ID_MAYEUCAU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<YEUCAU>()
                .HasMany(e => e.DONGYEUCAUs)
                .WithRequired(e => e.YEUCAU)
                .WillCascadeOnDelete(false);
        }
    }
}
