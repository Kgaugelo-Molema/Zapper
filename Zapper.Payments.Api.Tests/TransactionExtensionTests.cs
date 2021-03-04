using NUnit.Framework;
using Zapper.Payment.Api.Extensions;
using Zapper.Payment.Api.Models;

namespace Zapper.Payments.Api.Tests
{
    public class Tests
    {
        [Test]
        public void TransactionExtension_TipAmount_Is_Zero_If_Tip_Percent_Null()
        {
            var transaction = new Transaction
            {
                Amount = 100
            };

            Assert.AreEqual(transaction.CalculateTipTotal(), 0);
        }

        [Test]
        public void TransactionExtension_TipAmount_Calculates_Correctly_For_Percentage()
        {
            var transaction = new Transaction
            {
                Amount = 155,
                TipPercentage = 10
            };

            Assert.AreEqual(transaction.CalculateTipTotal(), 16);
        }
    }
}