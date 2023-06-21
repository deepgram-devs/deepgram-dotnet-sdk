﻿using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Deepgram.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Deepgram.Request
{
    public class ApiRequest
    {
        readonly HttpClient _httpClient;
        public ApiRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        internal async Task<T> SendHttpRequestAsync<T>(HttpRequestMessage request)
        {

            var response = await _httpClient.SendAsync(request);

            var stream = await response.Content.ReadAsStreamAsync();
            string json;
            using (var sr = new StreamReader(stream))
            {
                json = await sr.ReadToEndAsync();
            }


            var deepgramResponse = ProcessResponse(response, json);

            return JsonConvert.DeserializeObject<T>(deepgramResponse.JsonResponse);
        }

        private static DeepgramResponse ProcessResponse(HttpResponseMessage response, string json)
        {
            var logger = Logger.LogProvider.GetLogger(typeof(ApiRequest).Name);
            try
            {
                logger.LogDebug(json);
                response.EnsureSuccessStatusCode();
                return new DeepgramResponse
                {
                    Status = response.StatusCode,
                    JsonResponse = json
                };
            }
            catch (HttpRequestException exception)
            {
                logger.LogError($"FAIL: {response.StatusCode}");
                throw new DeepgramHttpRequestException(exception.Message) { HttpStatusCode = response.StatusCode, Json = json };
            }
        }

    }
}
