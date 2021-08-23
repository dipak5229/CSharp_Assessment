using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssessment
{
    public partial class GetTokenResponseDTO
    {
        public Account account { get; set; }
        public Tokens tokens { get; set; }
    }

    public class Core
    {
        public string currencyIsoCode { get; set; }
        public bool isExternalAccount { get; set; }
        public bool isExternalBalance { get; set; }
        public int registeredProductId { get; set; }
        public int userTypeId { get; set; }
        public int userId { get; set; }
        public string username { get; set; }
    }

    public class Balance2
    {
        public int typeId { get; set; }
        public double amountInAccountCurrency { get; set; }
    }

    public class PointBalance
    {
        public int typeId { get; set; }
        public double amount { get; set; }
    }

    public class Balance
    {
        public double totalInAccountCurrency { get; set; }
        public List<Balance> balances { get; set; }
        public List<PointBalance> pointBalances { get; set; }
        public bool isBonusEnabled { get; set; }
        public bool isExternalBonusEnabled { get; set; }
    }

    public class Account
    {
        public Core core { get; set; }
        public Balance balance { get; set; }
    }

    public partial class Tokens
    {
        public int userTokenExpiryInSeconds { get; set; }
        public List<string> launchTokens { get; set; }
        public List<string> refreshTokens { get; set; }
        public string userToken { get; set; }
    }

}
