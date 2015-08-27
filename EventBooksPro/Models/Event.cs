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
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        
        public IEnumerable<EventType> EventTypes { get; set; }
        public IEnumerable<Client> Clients { get; set; }

        public string ApplicationUserId { get; set; }
    }
}