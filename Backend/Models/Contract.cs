using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Contract
    {       
        public int Id { get; set; }
        public string Customer { get; set; }
        public ICollection<Site> Sites { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Money { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}