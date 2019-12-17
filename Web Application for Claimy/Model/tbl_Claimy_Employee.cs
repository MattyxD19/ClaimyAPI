namespace Web_Application_for_Claimy.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Claimy_Employee
    {
        [Key]
        [StringLength(50)]
        public string fld_Email { get; set; }

        [StringLength(50)]
        public string fld_Name { get; set; }

        [StringLength(50)]
        public string fld_Adress { get; set; }

        [StringLength(15)]
        public string fld_Phone_No { get; set; }

        [StringLength(25)]
        public string fld_Password { get; set; }

        public int? fld_Country_Number { get; set; }

        public virtual tbl_Country_List tbl_Country_List { get; set; }
    }
}
