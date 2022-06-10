using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Models.Data.Dto
{
    public class BatchDto
    {
        public string Status { get; set; }
        public int BusinessUnitId { get; set; }
       // public BusinessUnit businessUnit{get; set;}
         public Assignment_2.Models.Acl Acl { get; set; }
        public List<Models.Attribute> Attributes { get; set; }
        public List<FileAttribute> FileAttributes { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<File> Files { get; set; }
    }
}
