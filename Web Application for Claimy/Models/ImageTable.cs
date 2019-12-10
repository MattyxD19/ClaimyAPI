using System;
using System.ComponentModel.DataAnnotations;

namespace Web_Application_for_Claimy.Models
{
    public class ImageTable
    {
        public string ID { get; set; }

        [Required]
        public Byte[] Image { get; set; }

        //Foreign Key
        public TicketCaseTable Ticket_ID { get; set; }
    }
}