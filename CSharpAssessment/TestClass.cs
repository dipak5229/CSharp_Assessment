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
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var content = File.ReadAllText(Path.Combine(assemblyPath + @"\TestData\TokenTestData.json"));
            GetTokenRequestDTO testdata = JsonConvert.DeserializeObject<GetTokenRequestDTO>(content);

            var tokendata = new GetTokenRequestDTO();
            tokendata.userName = testdata.userName;
            tokendata.password = testdata.password;
            tokendata.sessionProductId = testdata.sessionProductId;
            tokendata.numLaunchTokens = testdata.numLaunchTokens;
            tokendata.marketType = testdata.marketType;
            tokendata.clientTypeId = testdata.clientTypeId;
            tokendata.languageCode = testdata.languageCode;

            var wrapper = new WrapperClass<GetTokenResponseDTO>();
            createToken = wrapper.getUserToken(TokenEndPoint, tokendata, guid);
            Assert.AreEqual(createToken.tokens.userToken, "JYDFGDFGFDGRTMPWZDFDFG");
        }

        [Test]
        public void PlayGameBalance()
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var content = File.ReadAllText(Path.Combine(assemblyPath+@"\TestData\GamePlayTestData.json"));
            PlayGameRequestDTO testdata = JsonConvert.DeserializeObject<PlayGameRequestDTO>(content);

            var GamePlay = new PlayGameRequestDTO();
            GamePlay.packetType = testdata.packetType;
            GamePlay.payload = testdata.payload;
            GamePlay.useFilter = testdata.useFilter;
            GamePlay.isBase64Encoded = testdata.isBase64Encoded;

            var GamePlayEndpoint = $"v1/games/module/{moduleId}/client/{clientId}/play";
            var wrapper2 = new WrapperClass<PlayGameResponseDTO>();

            var newToken = createToken.tokens.userToken; // "JYDFGDFGFDGRTMPWZDFDFG" ;
            var balance = wrapper2.GetBalance(GamePlayEndpoint, GamePlay, productId, moduleId, newToken);
            var amount = balance.Context.Balances.TotalInAccountCurrency;
            Assert.AreEqual(amount, "10000.0");
            //try
            //{
            //    var newToken = createToken.tokens.userToken; // "JYDFGDFGFDGRTMPWZDFDFG" ;
            //    var balance = wrapper2.GetBalance(GamePlayEndpoint, GamePlay, productId, moduleId, newToken);
            //    var amount = balance.Context.Balances.TotalInAccountCurrency;
            //    Assert.AreEqual(amount, "10000.0");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Empty Token returned: "+ e.StackTrace);
            //}
        }
    }
}
