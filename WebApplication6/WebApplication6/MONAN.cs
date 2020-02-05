namespace WebApplication6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MONAN")]
    public partial class MONAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONAN()
        {
            DONGTHANHTOANs = new HashSet<DONGTHANHTOAN>();
            DONGYEUCAUs = new HashSet<DONGYEUCAU>();
        }

        [Key]
        public int MAMON { get; set; }

        public int ID_MANHOM { get; set; }

        [StringLength(200)]
        public string TENMON { get; set; }

        public double? DONGIA { get; set; }

        [StringLength(100)]
        public string DONVITINH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONGTHANHTOAN> DONGTHANHTOANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONGYEUCAU> DONGYEUCAUs { get; set; }

        public virtual NHOMMONAN NHOMMONAN { get; set; }
    }
}
