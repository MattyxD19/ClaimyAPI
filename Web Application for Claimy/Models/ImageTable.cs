using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Application_for_Claimy.Models
{
    public class ImageTable
    {
        public int ID { get; set; }
        [Required]
        public Byte[] image { get; set; }
        
        //Foreign Key
        public TicketTable ticket_ID { get; set; }
    }
}