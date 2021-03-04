using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Zapper.Payment.Api.Models
{
    [DataContract(Name = "transaction")]
    public class Transaction
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "reference")]
        public string Reference { get; set; }
        [DataMember(Name = "currencyISOCode")]
        public string CurrencyIsoCode { get; set; }
        [DataMember(Name = "amount")]
        public int Amount { get; set; }
        [DataMember(Name = "tipPercentage")]
        public int? TipPercentage { get; set; }
        [DataMember(Name = "statusId")]
        public Status StatusId { get; set; }
        [DataMember(Name = "transactionUTCDate")]
        public DateTime TransactionUtcDate { get; set; }
        [DataMember(Name = "merchant")]
        public Merchant Merchant { get; set; }
        [DataMember(Name = "customer")]
        public Customer Customer { get; set; }
        [DataMember(Name = "card")]
        public Card Card { get; set; }

        public bool Valid()
        {
            var result = Amount <= 5000;
            return result;
        }
    }
}
