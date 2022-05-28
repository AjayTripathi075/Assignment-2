using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Models.Data.Dto
{
    public class BatchDto
    {
        public int BusinessUnitId { get; set; }
        public List<ReadUser> ReadUser { get; set; }
        public List<ReadGroup> ReadGroup { get; set; }
        public List<Attribute> Attribute { get; set; }
        public DateTime BatchPublishedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<File> Files { get; set; }
    }
}
