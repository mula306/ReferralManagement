using Newtonsoft.Json;
using ReferralManagement.Model;
using System.Net.Http.Headers;
using System.Text;

namespace ReferralManagement.Services
{
    public class DynamicReferralService : IDynamicReferralService
    {
        private readonly HttpClient _client;

        public DynamicReferralService(HttpClient client, IApiConfigurationService apiConfigurationService)
        {
            _client = client;
            _client.BaseAddress = new Uri(apiConfigurationService.GetBaseUri());
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<T> SendRequestAsync<T>(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                // Log the error response here
                Console.WriteLine($"Error: {response.StatusCode} when accessing {endpoint}");
                return default;
            }
        }

        public async Task<List<DynamicReferral>> GetDynamicReferrals()
        {
            var endpoint = $"/api/DynamicReferral/";
            return await SendRequestAsync<List<DynamicReferral>>(endpoint);
        }

        public async Task<DynamicReferral> GetDynamicReferralById(int id)
        {
            var endpoint = $"/api/DynamicReferral/{id}";
            var referral = await SendRequestAsync<DynamicReferral>(endpoint);
            return referral;
        }

        public async Task UpdateDynamicReferral(DynamicReferral dynamic)
        {
            var endpoint = $"/api/DynamicReferral/{dynamic.DynamicReferralId}";
            var formJson = JsonConvert.SerializeObject(dynamic);
            var httpContent = new StringContent(formJson, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(endpoint, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                // Handle error response here or throw an exception
            }
        }

        public async Task AddDynamicReferral(DynamicReferral dynamic)
        {
            var endpoint = $"/api/DynamicReferral";
            var formJson = JsonConvert.SerializeObject(dynamic);
            var httpContent = new StringContent(formJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(endpoint, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                // Handle error response here or throw an exception
            }
        }

    }
}

