namespace QuanLyNhanSu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            BANGCAPs = new HashSet<BANGCAP>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MANV { get; set; }

        [StringLength(50)]
        public string HOTEN { get; set; }

        public string DIACHI { get; set; }

        public int? SDT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYSINH { get; set; }

        public int? CMND { get; set; }

        [StringLength(50)]
        public string GIOITINH { get; set; }

        public string QUEQUAN { get; set; }

        [StringLength(50)]
        public string DANTOC { get; set; }

        public int? MAPB { get; set; }

        public int? SOSOBH { get; set; }

        [StringLength(50)]
        public string CHUCVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANGCAP> BANGCAPs { get; set; }

        public virtual PHONGBAN PHONGBAN { get; set; }
    }
}
