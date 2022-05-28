using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class FileAttribute
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        [JsonIgnore]
        public int FileId { get; set; }
        
    }
}
