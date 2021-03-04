using Zapper.Payment.Api.Models;

namespace Zapper.Payment.Api.Extensions
{
    public static class TransactionExtensions
    {
        public static int CalculateTipTotal(this Transaction transaction)
        {
            if (!transaction.TipPercentage.HasValue)
            {
                return 0;
            }
            double result = double.Parse(transaction.Amount.ToString()) * double.Parse(transaction.TipPercentage.Value.ToString()) / 100;
            result = System.Math.Round(result, 0);
            return int.Parse(result.ToString());
        }
    }
}
    