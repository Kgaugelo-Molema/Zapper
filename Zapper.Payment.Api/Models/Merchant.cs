using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Zapper.Payment.Api.Models
{
    public class Merchant
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [JsonIgnore]
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
