namespace Web_Application_for_Claimy.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Web_Application_for_Claimy.Models;

    public partial class tbl_Country_List
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Country_List()
        {
            tbl_Claimy_Employee = new HashSet<tbl_Claimy_Employee>();
            tbl_Customer = new HashSet<CustomerEntity>();
            tbl_Parking_Company = new HashSet<tbl_Parking_Company>();
        }

        [Key]
        public int fld_Number { get; set; }

        [StringLength(50)]
        public string fld_Country { get; set; }

        [StringLength(6)]
        public string fld_ZipCode { get; set; }

        [StringLength(50)]
        public string fld_City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Claimy_Employee> tbl_Claimy_Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerEntity> tbl_Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Parking_Company> tbl_Parking_Company { get; set; }
    }
}
