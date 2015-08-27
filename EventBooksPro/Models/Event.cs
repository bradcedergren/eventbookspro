using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace EventBooksPro.Models
{
    public class Event
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Event Name is required")]
        [Display(Name = "Event Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Event Date is required")]
        [Display(Name = "Event Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Event Start Time is required")]
        [Display(Name = "Start Time")]
        public int StartTime { get; set; }
        
        [Display(Name = "End Time")]
        public int EndTime { get; set; }

        [Display(Name = "Event Type")]
        public int EventTypeId { get; set; }

        [Display(Name = "Client Name")]
        public int ClientId { get; set; }

        public string ApplicationUserId { get; set; }
    }
}