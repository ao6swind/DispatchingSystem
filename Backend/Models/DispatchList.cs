using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class DispatchList
    {       
        public int Id { get; set; }
        public Site Site { get; set; }
        public User User { get; set; }
        public DateTime ReportedAt { get; set; }
        public IList<Record> CheckIn { get; set; }
        public IList<Record> CheckOut { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}