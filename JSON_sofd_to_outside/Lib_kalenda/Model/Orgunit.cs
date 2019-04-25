using Newtonsoft.Json;

namespace Lib_kalenda.Model
{
    internal class Orgunit
    {
        [JsonProperty(PropertyName = "Id", Required = Required.Always)]
        internal string Los_id { get; set; }

        [JsonProperty(PropertyName = "Parent_id", Required = Required.Always)]
        internal string Parent_losid { get; set; }

        [JsonProperty(PropertyName = "Name", Required = Required.Always)]
        internal string Name { get; set; }
    }
}
