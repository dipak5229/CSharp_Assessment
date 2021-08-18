using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssessment
{
    public class GetTokenRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SessionProductId { get; set; }
        public long NumLaunchTokens { get; set; }
        public string MarketType { get; set; }
        public long ClientTypeId { get; set; }
        public string LanguageCode { get; set; }
    }
}
