using System.Collections.Generic;
using System.Linq;

namespace Lib_Data.LORA
{
    public class EmployeeRepo : IRepo<kalenda_user>
    {
        private List<kalenda_user> tmp;

        public EmployeeRepo(string constr)
        {
            tmp = new List<kalenda_user>();
            tmp.Add(new kalenda_user()
            {
                Opus_id = 3,
                Orgunit_losid_fk = 2,
                Firstname = "Anders",
                Lastname = "And",
                Is_manager = false
            });
            tmp.Add(new kalenda_user()
            {
                Opus_id = 4,
                Orgunit_losid_fk = 2,
                Firstname = "Fætter",
                Lastname = "Vims",
                Is_manager = false
            });
            tmp.Add(new kalenda_user()
            {
                Opus_id = 2,
                Orgunit_losid_fk = 3,
                Firstname = "Fætter",
                Lastname = "Højben",
                Is_manager = false,
                Email = "luck@duck.com",
                Samaccount = "fortuna",
                Uuid = "luckluck-luckluckluck-lucklu-ck-luck"
            });
            tmp.Add(new kalenda_user()
            {
                Opus_id = 1,
                Orgunit_losid_fk = 1,
                Firstname = "Joakim",
                Lastname = "Von And",
                Is_manager = true,
                Email = "mcduck@duck.com",
                Samaccount = "scrooge",
                Uuid = "sadsadsad-sadsad-sadsadsad-sadsadsad"
            });
        }
        public IQueryable<kalenda_user> Query => tmp.AsQueryable();
    }

    public class kalenda_user
    {
        public int Opus_id { get; set; }
        public int Orgunit_losid_fk { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Samaccount { get; set; }
        public string Uuid { get; set; }
        public bool Is_manager { get; set; }
    }
}
