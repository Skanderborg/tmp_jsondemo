using Newtonsoft.Json;
using Lib_kalenda.Model;
using System.Collections.Generic;
using System.Text;
using Lib_Data;
using Lib_Data.LORA;
using System.Net;

namespace Lib_kalenda.Service
{
    public class JsonService
    {
        private IRepo<kalenda_user> empRepo;
        private IRepo<orgunit_full> orgRepo;

        public JsonService(string lora_sofd_constr)
        {
            empRepo = new EmployeeRepo(lora_sofd_constr);
            orgRepo = new OrgunitRepo(lora_sofd_constr);
        }

        /// <summary>
        /// Metode som poster JSON til endpoint, benytter naturligvis HTTPS, og apikey som sikkerhed. Vi kan godt lave andre former for sikkerhed hvis det er ønsket.
        /// C#'s standard webclient er extended fordi vi har ønsket en højere end default timeout, det kan justeres, men vi har erfaringer med, at det generelt er fint,
        /// at hæve lidt fra andre leverandøre.
        /// </summary>
        /// <param name="endPointUrl"></param>
        /// <param name="apiKey"></param>
        public void PostJson(string endPointUrl, string apiKey)
        {
            string json = GetJson();

            byte[] bytes = Encoding.UTF8.GetBytes(json);
            json = Encoding.UTF8.GetString(bytes);

            using (var client = new WebClientExtension())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers.Add("ApiKey", apiKey);
                client.Encoding = Encoding.UTF8;
                client.UploadString(endPointUrl, "POST", json);
                //var result = client.ResponseHeaders;
            }
        }

        public void SaveJsonToDisk()
        {
            string json = GetJson();
            System.IO.File.WriteAllText(@"c:\work\kalenda.json", json);
        }

        private string GetJson()
        {
            JsonObj jsonobj = new JsonObj();
            jsonobj.Orgunits = GetOrgUnits();
            jsonobj.Employees = GetEmployees();
            return JsonConvert.SerializeObject(jsonobj);
        }

        private List<Orgunit> GetOrgUnits()
        {
            List<Orgunit> res = new List<Orgunit>();
            foreach(orgunit_full db_org in orgRepo.Query)
            {
                Orgunit ou = new Orgunit()
                {
                    Los_id = db_org.Los_id.ToString(),
                    Name = db_org.Name,
                    Parent_losid = db_org.Parent_losid.ToString()
                };
                res.Add(ou);
            }
            return res;
        }

        private List<Employee> GetEmployees()
        {
            List<Employee> res = new List<Employee>();
            foreach(kalenda_user db_emp in empRepo.Query)
            {
                Employee emp = new Employee()
                {
                    Opus_id = db_emp.Opus_id.ToString(),
                    Orgunit_losid_fk = db_emp.Orgunit_losid_fk.ToString(),
                    Firstname = db_emp.Firstname,
                    Lastname = db_emp.Lastname,
                    Is_manager = db_emp.Is_manager.ToString(),
                    Email = db_emp.Email ?? "",
                    Samaccount = db_emp.Samaccount ?? "",
                    Uuid = db_emp.Uuid ?? ""
                };
                res.Add(emp);
            }
            return res;
        }
        
    }
}
