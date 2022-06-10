using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Models.Data.Dto
{
    public class ViewBatchDto
    {
        public Guid BatchId { get; set; }
        public string Status { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public ReadUser[] ReadUsers { get; set; }
        public ReadGroup[] ReadGroups { get; set; }
        public List<FileAttribute> Attributes { get; set; }
        public DateTime BatchPublishedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<File> Files { get; set; }
    }
}
