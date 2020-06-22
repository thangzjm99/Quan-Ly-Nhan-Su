namespace QuanLyNhanSu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANGCAP")]
    public partial class BANGCAP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MABC { get; set; }

        public int? MANV { get; set; }

        [StringLength(50)]
        public string TENBC { get; set; }

        [StringLength(50)]
        public string LOAIBC { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYCAP { get; set; }

        public string DVCAP { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
