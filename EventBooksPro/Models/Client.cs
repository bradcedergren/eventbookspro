﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventBooksPro.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string ContactName { get; set; }
    }
}