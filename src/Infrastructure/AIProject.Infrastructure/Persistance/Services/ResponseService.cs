using AIProject.Application.Common.Interfaces;
using AIProject.Application.Common.Models;
using AIProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Infrastructure.Persistance.Services
{
    public class ResponseService : IResponseService
    {
        public async Task<AIResponse> GetResponse()
        {
            AIResponse aIResponse = new();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://chatgpt-42.p.rapidapi.com/chatgpt"),
                Headers =
                {
                    { "x-rapidapi-key", "d39e1cac24msh4d1ad610a923927p1a3f19jsn24b8704cfa5f" },
                    { "x-rapidapi-host", "chatgpt-42.p.rapidapi.com" },
                },
                Content = new StringContent("{\"messages\":[{\"role\":\"user\",\"content\":\"Generate 5 sentences in English at A1 level.Format:Json,Only give me my json data.Do not add additional text\"}],\"web_access\":false}")
                {
                    Headers =
                        {
                        ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                aIResponse.Response = body;
            }
            return aIResponse;
        }
    }
}
