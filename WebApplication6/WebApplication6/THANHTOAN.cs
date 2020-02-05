namespace WebApplication6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANHTOAN")]
    public partial class THANHTOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THANHTOAN()
        {
            DONGTHANHTOANs = new HashSet<DONGTHANHTOAN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MATHANHTOAN { get; set; }

        public int ID_MAYEUCAU { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYTT { get; set; }

        public int TRANGTHAI { get; set; }

        public int ID_MANHANVIEN { get; set; }

        public double? TONGTIEN { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONGTHANHTOAN> DONGTHANHTOANs { get; set; }

        public virtual YEUCAU YEUCAU { get; set; }
    }
}
