using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project2.Models
{
    public class blob
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Timestamp { get; set; }

    }
}
