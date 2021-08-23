// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CSharpAssessment
{
    [TestFixture]
    public class TestClass
    {
        string TokenEndPoint = "accounts/login/real";
        public static TestContext testContext { get; set; }
        

        // Getting attributes from config file
        public string clientId = System.Configuration.ConfigurationManager.AppSettings["clientId"];
        public string moduleId = System.Configuration.ConfigurationManager.AppSettings["moduleId"];
        public string productId = System.Configuration.ConfigurationManager.AppSettings["productId"];
        public string guid = System.Configuration.ConfigurationManager.AppSettings["guid"];
        public GetTokenResponseDTO createToken;

        [Test]
        public void GetToken()
        {
            var content = File.ReadAllText(@"D:\Users\dipakj\source\repos\CSharpAssessment\CSharpAssessment\TestData\TokenTestData.json");
            GetTokenRequestDTO testdata = JsonConvert.DeserializeObject<GetTokenRequestDTO>(content);

            var tokendata = new GetTokenRequestDTO();
            tokendata.UserName = testdata.UserName;
            tokendata.Password = testdata.Password;
            tokendata.SessionProductId = testdata.SessionProductId;
            tokendata.NumLaunchTokens = testdata.NumLaunchTokens;
            tokendata.MarketType = testdata.MarketType;
            tokendata.ClientTypeId = testdata.ClientTypeId;
            tokendata.LanguageCode = testdata.LanguageCode;

            var wrapper = new WrapperClass<GetTokenResponseDTO>();
            createToken = wrapper.getUserToken(TokenEndPoint, tokendata, guid);
        }

        [Test]
        public void PlayGameBalance()
        {
            var content = File.ReadAllText(@"D:\Users\dipakj\source\repos\CSharpAssessment\CSharpAssessment\TestData\GamePlayTestData.json");
            PlayGameRequestDTO testdata = JsonConvert.DeserializeObject<PlayGameRequestDTO>(content);

            var GamePlay = new PlayGameRequestDTO();
            GamePlay.packetType = testdata.packetType;
            GamePlay.payload = testdata.payload;
            GamePlay.useFilter = testdata.useFilter;
            GamePlay.isBase64Encoded = testdata.isBase64Encoded;

            var GamePlayEndpoint = $"v1/games/module/{moduleId}/client/{clientId}/play";
            var wrapper2 = new WrapperClass<PlayGameResponseDTO>();
            
            try
            {
                var newToken = createToken.tokens.userToken;
                var balance = wrapper2.GetBalance(GamePlayEndpoint, GamePlay, productId, moduleId, newToken);
            }
            catch (Exception e)
            {
                Console.WriteLine("Empty Token returned: "+ e.StackTrace);
            }
        }
    }
}
