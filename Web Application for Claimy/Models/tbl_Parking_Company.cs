namespace Web_Application_for_Claimy.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Parking_Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Parking_Company()
        {
            tbl_Ticket_Case = new HashSet<tbl_Ticket_Case>();
        }

        [Key]
        [StringLength(10)]
        public string fld_CVRNR { get; set; }

        [StringLength(50)]
        public string fld_Name { get; set; }

        [StringLength(50)]
        public string fld_Adress { get; set; }

        [StringLength(50)]
        public string fld_Email { get; set; }

        [StringLength(15)]
        public string fld_Phone_No { get; set; }

        [StringLength(50)]
        public string fld_Contact_Person { get; set; }

        public int? fld_Country_Number { get; set; }

        public virtual tbl_Country_List tbl_Country_List { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Ticket_Case> tbl_Ticket_Case { get; set; }
    }
}
