using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Models.Error
{
    public class CorRelation
    { 

        public Guid CorRelationId { get; set;}
        public List<Error> Errors { get; set;}

    }
}
