using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Zapper.Payment.Api.Models
{
    public class Customer
    {
        [JsonIgnore]
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}
