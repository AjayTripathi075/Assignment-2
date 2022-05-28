using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    
    public class BusinessUnit
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Description { get; set; }
       
    }
}
