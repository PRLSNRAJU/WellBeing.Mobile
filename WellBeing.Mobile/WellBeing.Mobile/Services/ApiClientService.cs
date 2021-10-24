using Common.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WellBeing.Mobile.Services
{
    public class ApiClientService
    {
        HttpClient _httpClient = new HttpClient();

        public async Task<string> sendRequest<T>(string url, HttpMethod method, T obj)
        {
            HttpRequestMessage req;
            if (method == HttpMethod.Get)
            {
                req = new HttpRequestMessage()
                {
                    Method = method,
                    RequestUri = new Uri(url),
                };
            }
            else
            {
                req = new HttpRequestMessage()
                {
                    Method = method,
                    RequestUri = new Uri(url),
                    Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
                };
            }

            var res =  _httpClient.SendAsync(req).Result;
            var text = await res.Content.ReadAsStringAsync();

            return text;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var resp = await sendRequest("https://l8pqv3r0fd.execute-api.ap-south-1.amazonaws.com/Prod/api/users", System.Net.Http.HttpMethod.Get, "");

            return JsonConvert.DeserializeObject<List<UserDto>>(resp);
        }

        public async Task AddUser(UserDto user)
        {
            await sendRequest("https://l8pqv3r0fd.execute-api.ap-south-1.amazonaws.com/Prod/api/users", System.Net.Http.HttpMethod.Post, user);
            //return JsonConvert.DeserializeObject<UserDto>(resp);
        }

        public void UpdateSteps(UserStepsDto userSteps)
        {
            var resp = sendRequest("https://l8pqv3r0fd.execute-api.ap-south-1.amazonaws.com/Prod/api/user", System.Net.Http.HttpMethod.Post, userSteps).Result;
            //return JsonConvert.DeserializeObject<UserStepsDto>(resp);
        } 

        public UserStepsDto GetUserSteps(UserStepsDto userSteps)
        {
            var resp = sendRequest("https://l8pqv3r0fd.execute-api.ap-south-1.amazonaws.com/Prod/api/user", System.Net.Http.HttpMethod.Get, userSteps).Result;
            return JsonConvert.DeserializeObject<UserStepsDto>(resp);
        }

        public async Task<List<UserStepsDto>> GetAllUserSteps()
        {
            var resp = await sendRequest("https://l8pqv3r0fd.execute-api.ap-south-1.amazonaws.com/Prod/api/user", System.Net.Http.HttpMethod.Get, "");
            return JsonConvert.DeserializeObject<List<UserStepsDto>>(resp);
        }
    }
}
