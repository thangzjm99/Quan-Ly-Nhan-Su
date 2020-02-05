namespace WebApplication6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DATBAN")]
    public partial class DATBAN
    {
        [Key]
        public int MADATBAN { get; set; }

        public int ID_MABAN { get; set; }

        public int ID_MAKHACHHANG { get; set; }

        [Column(TypeName = "date")]
        public DateTime TGDAT { get; set; }

        [Column(TypeName = "date")]
        public DateTime TGNHAN { get; set; }

        [Column(TypeName = "date")]
        public DateTime TGHUY { get; set; }

        public virtual BANAN BANAN { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
