using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class File
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string MimeType { get; set; }
        public string Hash { get; set; }
        public List<FileAttribute> FileAttribute { get; set; }
        [JsonIgnore]
        public Guid BatchId { get; set; }


    }
}
