namespace WebApplication6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DATBANs = new HashSet<DATBAN>();
            YEUCAUs = new HashSet<YEUCAU>();
        }

        [Key]
        public int MAKHACHHANG { get; set; }

        [Required]
        [StringLength(200)]
        public string TENKHACHHANG { get; set; }

        public int? SDT { get; set; }

        [Required]
        [StringLength(1000)]
        public string DIACHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATBAN> DATBANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YEUCAU> YEUCAUs { get; set; }
    }
}
