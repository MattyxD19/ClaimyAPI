namespace Web_Application_for_Claimy.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_Image_ID { get; set; }

        public byte[] fld_image { get; set; }

        [StringLength(50)]
        public string fld_Ticket_ID { get; set; }

        public virtual tbl_Ticket_Case tbl_Ticket_Case { get; set; }
    }
}
