using Assignment_2.Data;
using Assignment_2.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2.data
{
    public class repositorybuilder
    {
        public readonly BatchRepository  batchRepository = null;
      

        public repositorybuilder()
        {
            BatchDbContextBuilder contextbuilder = new BatchDbContextBuilder();
            var context = contextbuilder.CreateDbContext(new string[] { string.Empty });

            this.batchRepository = new BatchRepository(context);
        }
    }
}
