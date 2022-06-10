using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class ReadGroup
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string GroupName { get; set; }
        [JsonIgnore]
        public int AclId { get; set; }

    }
}
