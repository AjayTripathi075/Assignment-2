using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class Batch
    {
        [JsonIgnore]
        public Guid BatchId { get; set; }
        public string Status { get; set;}
        [JsonIgnore]
        public int BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public Acl Acl { get; set; }
        public List<Attribute> Attributes { get; set; }
        public DateTime BatchPublishedDate { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; }
        public List<File> Files { get; set; }
    }
}
