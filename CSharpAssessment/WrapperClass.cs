using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssessment
{
    class WrapperClass<T>
    {
        public GetTokenResponseDTO getUserToken(string endpoint, dynamic payload, string guid)
        {
            var user = new HelperClass<GetTokenRequestDTO>();
            var url = user.setUrl(endpoint);
            var jsonReq = user.serialize(payload);
            var request = user.CreateTokenPostRequest(jsonReq, guid);
            var responce = user.GetResponce(url, request);
            GetTokenResponseDTO content = user.GetContent<GetTokenResponseDTO>(responce);
            return content;

        }

        public PlayGameResponseDTO GetBalance(string endpoint, dynamic payload, string productID, String ModuleID, string token)
        {
            var user = new HelperClass<PlayGameRequestDTO>();
            var url = user.setUrl(endpoint);
            var jsonReq = user.serialize(payload);
            var request = user.CreateGamePlayPostRequest(jsonReq, productID, ModuleID, token);
            var responce = user.GetResponce(url, request);
            PlayGameResponseDTO content = user.GetContent<PlayGameResponseDTO>(responce);
            return content;

        }
    }
}
