using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventBooksPro.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        
        public string ApplicationUserId { get; set; }
    }
}