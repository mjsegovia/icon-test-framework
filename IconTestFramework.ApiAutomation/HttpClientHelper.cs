using IconTestFramework.Core.Config;
using IconTestFramework.Core.Domain;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IconTestFramework.ApiAutomation
{
    public class HttpClientHelper
    {
        private RestClient _client;
        private Uri _baseUrl;       

        public RestResponse Response;
        public UserResponse UserResponse;

        public HttpClientHelper() 
        {
            _baseUrl  = new Uri(Configurator.ApiUrl);
            _client = new RestClient(_baseUrl);
        }       

        public async Task<T> GetTAsync<T>(string endPoint) where T : new()
        {
            var request = new RestRequest(endPoint, Method.Get);

            var response = await _client.ExecuteAsync<T>(request);
            Response = response;            

            HandleErrors(response);

            if (response.IsSuccessful && response.Data != null)
                return response.Data;
            else
                throw new Exception($"Failed to fetch data. Status code: {response.StatusCode}, Error message: {response.ErrorMessage}");           
        }

        //Generic GET method with params
        public async Task<T> GetTWithParamsAsync<T>(string endPoint, Dictionary<string, string> queryParams) where T : new()
         {
            var request = new RestRequest(endPoint, Method.Get); 

            //Iterate over the params
            queryParams.ToList().ForEach(param => request.AddParameter(param.Key, param.Value));            

            var response = await _client.ExecuteAsync<T>(request);
            Response = response;

            HandleErrors(response);

            return response.Data;          
         }

        //Adding parameter to Uri
        private void AddParametersUri(RestRequest request, string parameter, string value)
        {
            request.AddParameter(parameter, value);            
        }

        //Private method to handle errors
        private void HandleErrors(RestResponse response)
        {
            if (!response.IsSuccessful)
                throw new SystemException($"Error: {response.StatusCode} - {response.ErrorMessage}");
        }        
    }
}