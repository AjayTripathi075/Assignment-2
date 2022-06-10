using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class Acl
    {
        [JsonIgnore]
        public int Id { get; set; }
        public List<ReadUser> ReadUsers { get; set; }
        public List<ReadGroup> ReadGroups { get; set; }
        [JsonIgnore]
        public Guid BatchId { get; set; }
    }
}
