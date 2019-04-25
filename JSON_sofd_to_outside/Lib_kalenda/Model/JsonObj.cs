using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lib_kalenda.Model
{
    internal class JsonObj
    {
        [JsonProperty(PropertyName = "Orgunits", Required = Required.Always)]
        internal List<Orgunit> Orgunits { get; set; }

        [JsonProperty(PropertyName = "Employees", Required = Required.Always)]
        internal List<Employee> Employees { get; set; }
    }
}
