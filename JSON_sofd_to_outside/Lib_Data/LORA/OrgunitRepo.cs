using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Data.LORA
{
    public class OrgunitRepo : IRepo<orgunit_full>
    {
        private List<orgunit_full> tmp;

        public OrgunitRepo(string constr)
        {
            tmp = new List<orgunit_full>();
            tmp.Add(new orgunit_full()
            {
                Los_id = 1,
                Name = "Mcduck enterprises",
                Parent_losid = 0
            });
            tmp.Add(new orgunit_full()
            {
                Los_id = 2,
                Name = "Rengøring",
                Parent_losid = 1
            });
            tmp.Add(new orgunit_full()
            {
                Los_id = 3,
                Name = "Von And Spil",
                Parent_losid = 1
            });
        }
        public IQueryable<orgunit_full> Query => tmp.AsQueryable();
    }

    public class orgunit_full
    {
        public int Los_id { get; set; }
        public int Parent_losid { get; set; }
        public string Name { get; set; }
    }
}
