using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [NotMapped]
    public class Record
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime DateTime { get; set; }
    }
}