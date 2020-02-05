namespace WebApplication6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONGYEUCAU")]
    public partial class DONGYEUCAU
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAYEUCAU { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_MAMON { get; set; }

        public int? SOLUONG { get; set; }

        public double? THANHTIEN { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TRANGTHAI { get; set; }

        public virtual MONAN MONAN { get; set; }

        public virtual YEUCAU YEUCAU { get; set; }
    }
}
