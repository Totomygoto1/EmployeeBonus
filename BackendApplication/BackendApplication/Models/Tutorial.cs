using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BackendApplication.Models
{
    public class Tutorial
    {
        public int id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        public DateTimeOffset published { get; set; }

    }
}
