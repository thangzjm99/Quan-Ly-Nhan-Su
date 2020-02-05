namespace WebApplication6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONGTHANHTOAN")]
    public partial class DONGTHANHTOAN
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MATHANHTOAN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_MAMON { get; set; }

        public int? SOLUONG { get; set; }

        public double? THANHTIEN { get; set; }

        public virtual MONAN MONAN { get; set; }

        public virtual THANHTOAN THANHTOAN { get; set; }
    }
}
