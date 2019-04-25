using Newtonsoft.Json;

namespace Lib_kalenda.Model
{
    internal class Employee
    {
        [JsonProperty(PropertyName = "Employee_nr", Required = Required.Always)]
        internal string Opus_id { get; set; }

        [JsonProperty(PropertyName = "Orgunit_id", Required = Required.Always)]
        internal string Orgunit_losid_fk { get; set; }

        [JsonProperty(PropertyName = "Firstname", Required = Required.Always)]
        internal string Firstname { get; set; }

        [JsonProperty(PropertyName = "Lastname", Required = Required.Always)]
        internal string Lastname { get; set; }

        [JsonProperty(PropertyName = "Email", Required = Required.Default)]
        internal string Email { get; set; }

        [JsonProperty(PropertyName = "Samaccount", Required = Required.Default)]
        internal string Samaccount { get; set; }

        [JsonProperty(PropertyName = "UUID", Required = Required.Default)]
        internal string Uuid { get; set; }

        [JsonProperty(PropertyName = "Is_manager", Required = Required.Always)]
        internal string Is_manager { get; set; }
    }
}
