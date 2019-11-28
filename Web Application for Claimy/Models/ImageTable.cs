using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Web_Api_Claimy.Models
{
    public class ImageTable
    {
        public int fld_ID { get; set; }
        [Required]

        public Image fld_Image { get; set; }

        public string fld_Description { get; set; }

        //foreign key
        public int fld_Ticket_ID { get; set; }
        // property Navigation 
        public TicketTable ticket { get; set; }
    }
}